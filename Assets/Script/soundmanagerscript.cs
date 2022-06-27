using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanagerscript : MonoBehaviour
{
    public AudioClip runsound, checkpointsound, jumpsound, deadsound;
    public AudioSource audiosrc;
    
    // Start is called before the first frame update
    void Start()
    {
        jumpsound = Resources.Load<AudioClip>("jump");
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audiosrc.PlayOneShot(jumpsound);
                break;
        }
    }
}
