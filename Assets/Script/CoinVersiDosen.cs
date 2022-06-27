using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinVersiDosen : MonoBehaviour
{
    CharaVersiDosen chara;
    // Start is called before the first frame update
    public int score = 0;
    void Start()
    {
        chara = GameObject.Find("chara").GetComponent<CharaVersiDosen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            chara.koin += 5;
            Destroy(gameObject);
            chara.coinsound.Play();
        }
    }
}
