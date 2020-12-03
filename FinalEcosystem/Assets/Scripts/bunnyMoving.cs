using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bunnyMoving : MonoBehaviour
{
    public Transform Predator;
    float mSpeed = 5f;
    //bunny Bunny;
    public int maxPosX;
    public int maxPosZ;
    public int minPosX;
    public int minPosZ;
    public GameObject bunnyGo;
    public bool gettingNearWall = false;
    Rigidbody body;
    float bunnyHop;
    void Start()
    {
        // Bunny = new bunny();
        
        body = GetComponent<Rigidbody>();
        body.isKinematic = false;
        body.useGravity = false;
        body.position = new Vector3(22f, 6.5f, 30f);
        
}


    void FixedUpdate()
    {
        //Bunny.Motion();

       // body.transform.LookAt(Predator.position);
       
        bunnyHop = Mathf.PerlinNoise(.0f, .5f);
        Debug.Log(bunnyHop);

      //  body.transform.Translate(0.0f, bunnyHop, -mSpeed * Time.deltaTime);

       // body.transform.LookAt(Predator.position);
        //body.transform.Translate(0.0f, bunnyHop, -mSpeed * Time.deltaTime);

        
      /*  
        if (body.transform.position.z < maxPosZ)
        {
            //transform.Translate(-mSpeed * Time.deltaTime, bunnyHop, 0f);
           // gettingNearWall = true;
            Debug.Log("Is reaching the end of z");
        }
        else if (body.transform.position.z > minPosZ)
        {
           // transform.Translate(-mSpeed * Time.deltaTime, bunnyHop, 0f);
            Debug.Log("Reaching the top of the map z ");
           // gettingNearWall = true;
        }
        else if (body.transform.position.x < maxPosX)
        {
           // transform.Translate(0f, bunnyHop, -mSpeed * Time.deltaTime);
            Debug.Log("Is reaching the end of X");
            ///gettingNearWall = true;
        }
        else if (body.transform.position.x > minPosX)
        {
            //transform.Translate(0f, bunnyHop, -mSpeed * Time.deltaTime);
            Debug.Log("Reaching the other side of x");
            //gettingNearWall = true;
        }
        else if (gettingNearWall == false)
        {
            body.transform.Translate(0.0f, bunnyHop, -mSpeed * Time.deltaTime);
        }
        else
        {
            //transform.Translate(0.0f, bunnyHop, -mSpeed * Time.deltaTime);
            Debug.Log("Being Chased");
        }
        */

    }


    
}



