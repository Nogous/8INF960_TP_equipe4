using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed; // Vitesse de mouvement
    public Rigidbody2D rb; // Notre personnage
    public Animator animator; // Animation personnage
    public SpriteRenderer spriteRenderer; // Visuel du personnage

    private bool jump = false;
    public bool isGrounded = false;
    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;

    private Vector3 velocity = Vector3.zero;

    private float horizontalMov;

    // health
    public int health = 10;
    public float invincibilityDuration = 2f;
    public float invincibilityCountdawn = 0f;
    private bool isInvincible = false;

    [SerializeField]
    private SpriteRenderer sprite;

    private void Start()
    {
        GameManager.instance.SetMaxHealth(health);
    }

    void Update() // Update s'actualise sans arret
    {
        if (GameManager.instance.levelEnd)
        {
            if (horizontalMov>0f)
            {
                horizontalMov -= Time.deltaTime*10;
                if (horizontalMov < 0f)
                    horizontalMov = 0f;
            }
            else if(horizontalMov < 0f)
            {
                horizontalMov += Time.deltaTime*10;
                if (horizontalMov > 0f)
                    horizontalMov = 0f;
            }
            return;
        }


        // Vitesse de déplacement du personnage vers la gauche ou la droite au cours du temps (axe Horizontal)
        horizontalMov = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        // AUssi logntemps qu'on appuie sur la touche, on déplace

        // On définit un cercle qui détermine si oui ou non on est sur le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);
        // Saver si le joueur va sauter
        if (Input.GetButtonDown("Jump") && isGrounded == true) // Jump défnit sur la barre espace de base
        {
            jump = true;
        }

        Flip(rb.velocity.x);
        // Problème, si déplacement à gauche, vélocité négative (déplacement sens opposé) donc on créée une variable temporairequi rend valeur asbolue
        float tempCharacterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", tempCharacterVelocity);

        // invincibility gestion
        if (isInvincible)
        {
            Blink();
            invincibilityCountdawn -= Time.deltaTime;
            if (invincibilityCountdawn <= 0f)
            {
                sprite.color = Color.white;
                isInvincible = false;
            }
        }
    }

    void FixedUpdate() { // S'actualise dans des temps bien précis
        MovePlayer(horizontalMov);
    }

    void MovePlayer(float _horizontalMov) {
        // DIrection de dep elle va etre sur horizontalMove calculé au dessus sur l'axe x, mais il faut également préciser l'axe vertical (car vecteur2)
        // On va lui laisser la valeur par défault
        Vector3 targetVelocity = new Vector2(_horizontalMov, rb.velocity.y);
        // déplacement lisse du rb, ref -> nomenclature de unity
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        if (jump == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    // La vélocité de l'axe x va être négative, donc c'est simple de pouvoir flip le personnage
    void Flip(float _velocity)
    {
        if(_velocity > 0.1f) // On ne met pas 0 car l'animateur ne sait pas quoi faire, donc ce sont des valeurs de "sécurité"(de même pour le 0.3 dans Wait à Run dans l'animation)
        {
            spriteRenderer.flipX = false;
        } else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);

        }
        else if (collision.CompareTag("Ennemie"))
        {
            if (isInvincible) return;

            health -= 1;
            if (health<=0)
                animator.SetBool("isDead", true);
            else
            {
                isInvincible = true;
                invincibilityCountdawn = invincibilityDuration;
            }
            GameManager.instance.SetHealth(health);
        }
        else if (collision.CompareTag("KillZone"))
        {
            health = 0;
            animator.SetBool("isDead", true);
            GameManager.instance.SetHealth(health);
        }
    }

    private void Blink()
    {
        if (sprite.color == Color.red)
            sprite.color = Color.white;
        else
            sprite.color = Color.red;
    }
}