using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemyTwo : MonoBehaviour
{
    public Transform[] waypoints;
    public SpriteRenderer graphics;
    public float jumpForce;
    public bool isJumping=false;
    public Rigidbody2D rb;
    public bool touchGround;
    private Transform target;
    private int destPoint=0;

    // Start is called before the first frame update
    void Start()
    {
        target=waypoints[0];
        rb = GetComponent<Rigidbody2D>();
    }

    
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ground"))
        {
            touchGround=true;
             rb.AddForce(new Vector2(0f,jumpForce));
        isJumping=false;
        }else{touchGround=false;}
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * GameManager.instance.speedEnemie * Time.deltaTime, Space.World);

        if(touchGround==true){
            isJumping=true;
            touchGround=false;
        }
       

        // si l'enemi est quasiment arrivé à sa destination
        if(Vector3.Distance(transform.position,target.position)<0.3f)
        {
            destPoint=(destPoint+1)%waypoints.Length;
            target=waypoints[destPoint];
            graphics.flipX= !graphics.flipX;

        }
    }
}