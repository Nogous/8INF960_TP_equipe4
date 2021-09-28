using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private List<AudioSource> sources;

    private void Awake()
    {
        if (!SoundManager.instance)
        {
            SoundManager.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlaySound(string soundName)
    {
        for (int i = sources.Count; i-->0;)
        {
            if (soundName == sources[i].gameObject.name)
            {
                sources[i].Play();
                return;
            }
        }

        Debug.Log("La source audio \"" +soundName+"\" n'est pas referancer dans la liste de sources du SoundManager");
    }
}
