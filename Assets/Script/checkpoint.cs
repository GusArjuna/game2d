using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public Sprite crankdown, crankup;
    private SpriteRenderer checkpointrenderer;
    public bool cekcheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        checkpointrenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkpointrenderer.sprite = crankup;
            cekcheckpoint = true;
        }
    }
}
