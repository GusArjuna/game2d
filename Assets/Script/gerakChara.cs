using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class gerakChara : MonoBehaviour
{
    // Start is called before the first frame update
    public int kecepatan,kekuatanLompat,pindah;
    private Rigidbody2D lompat;
    public bool baliks,tanah;
    public LayerMask targetLayer;
    public Transform deteksiTanah;
    public float threshold;
    
    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        tanah = Physics2D.OverlapCircle(deteksiTanah.position, threshold, targetLayer);
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector2.right*kecepatan*Time.deltaTime);
            pindah = -1;
        }else if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector2.left*kecepatan*Time.deltaTime);
            pindah = 1;
        }

        if (Input.GetKey(KeyCode.Space)&&tanah==true)
        {
            lompat.AddForce(new Vector2(0,kekuatanLompat));
        }

        if (pindah>0&&!baliks)
        {
            balik();
        }else if (pindah<0&&baliks)
        {
            balik();
        }
    }

    void balik()
    {
        baliks = !baliks;
        Vector3 chara = transform.localScale;
        chara.x *= -1;
        transform.localScale = chara;
    }
}