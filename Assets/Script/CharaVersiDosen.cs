using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaVersiDosen : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f,movement = 0f,jump=5f,threshold;
    private Rigidbody2D jumps;
    public bool landCheck,ismoving;
    public LayerMask targetLayer;
    public Transform landDetected;
    private Animator animate;
    public Vector3 respawnPoint;
    private Text coininfo,lifeinfo;
    public int koin,nyawa=3;
    public AudioSource runsound, checkpointsound, jumpsound, deadsound,coinsound,winsounnd,losesound;
    public GameObject wins, loses;

    void Start()
    {
        jumps = GetComponent<Rigidbody2D>();
        coininfo = GameObject.Find("UIKoin").GetComponent<Text>();
        lifeinfo = GameObject.Find("UINyawa").GetComponent<Text>();
        animate = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        coininfo.text = "Score : " + koin.ToString();
        lifeinfo.text = "Life : " + nyawa.ToString();
        landCheck = Physics2D.OverlapCircle(landDetected.position, threshold, targetLayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0)
        {
            ismoving = true;
            jumps.velocity = new Vector2(movement * speed, jumps.velocity.y);
            transform.localScale = new Vector2(2.927169f, 2.989169f);
        }
        else if (movement < 0)
        {
            ismoving = true;
            jumps.velocity = new Vector2(movement * speed, jumps.velocity.y);
            transform.localScale = new Vector2(-2.927169f, 2.989169f);
        }
        else if (movement == 0)
        {
            ismoving = false;
        }

        if (ismoving)
        {
            if (!runsound.isPlaying)
            {
                runsound.Play();
            }
        }else
        {
            runsound.Stop();
        }
        if (Input.GetButtonDown("Jump") && landCheck)
        {
            jumps.velocity = new Vector2(jumps.velocity.x, jump);
            jumpsound.Play();
        }
        animate.SetFloat("movements", Mathf.Abs(jumps.velocity.x));
        animate.SetBool("onLand", landCheck);

        if (nyawa == 0)
        {
            Destroy(gameObject);
            loses.SetActive(true);
            runsound.Stop();
            losesound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "falldetector")
        {
            deadsound.Play();
            transform.position = respawnPoint;
            nyawa--;
        }
        
        if (other.tag == "checkpoint")
        {
            checkpointsound.Play();
            respawnPoint = other.transform.position;
        }

        if (other.tag=="outing"&&koin==25)
        {
            Destroy(gameObject);
            wins.SetActive(true);
            winsounnd.Play();
            runsound.Stop();
        }
    }
}
