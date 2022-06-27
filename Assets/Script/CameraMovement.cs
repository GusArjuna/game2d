using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject mainChara;
    public float offset,offsetSmooth;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(mainChara.transform.position.x,mainChara.transform.position.y,transform.position.z);
        if (mainChara.transform.localScale.x>0f)
        {
            playerPosition = playerPosition = new Vector3(mainChara.transform.position.x + offset,mainChara.transform.position.y,transform.position.z);
        }
        else 
        {
            playerPosition = playerPosition = new Vector3(mainChara.transform.position.x - offset,mainChara.transform.position.y,transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position,playerPosition,offsetSmooth*Time.deltaTime);

    }
}
