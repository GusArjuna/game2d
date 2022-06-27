using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class enemys : MonoBehaviour
{
    public bool hadap = true;
    public AIPath Aipath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Aipath.desiredVelocity.x>0f&&hadap==true)
        {
            transform.Rotate(0f,180f,0f);
            hadap = false;
        }else if (Aipath.desiredVelocity.x<0f&&hadap==false)
        {
            transform.Rotate(0f,180f,0f);
            hadap = true;
        }
    }
}
