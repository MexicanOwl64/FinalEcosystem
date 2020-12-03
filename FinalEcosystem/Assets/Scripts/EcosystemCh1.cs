using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EcosystemCh1 : MonoBehaviour
{
   
    float mSpeed = 5f;
    bunny Bunny;


    void Start()
    {
        Bunny = new bunny();
    }


    void FixedUpdate()
    {
        Bunny.Motion();
        
        
    }


}



public class bunny
{
    private Vector3 location, velocity, acceleration;
    private float topSpeed;
    public Rigidbody body;
    private GameObject bunnyGO;
    public float speed = 10f;
    public bunny()
    {
        location = Vector3.zero;
        velocity = Vector3.zero;
        acceleration = new Vector3(.0f, 10f, .0f);
        
        
        topSpeed = 20f;
        bunnyGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        body = bunnyGO.AddComponent<Rigidbody>();

        body.transform.position = new Vector3(0, 5, 0);
        bunnyGO.transform.position = new Vector3(0, 5, 0);
    }

    public void Motion()
    {

        
        //float bunnyHop = body.position.y * Time.deltaTime * speed;

      
        body.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                
        //Debug.Log(location.y);
        if (body.position.y == 0)
        {
            float bunnyHop = body.position.y * Time.deltaTime * speed;
            body.transform.position = new Vector3(0, bunnyHop, 0);
            Debug.Log(body.position.y);
            Debug.Log("Is touching floor");
            Debug.Log(bunnyHop);

            
        }
        else if (body.position.y > 5)
        {

            //bunnyGO.transform.position = new Vector3(0, height, 0);
           
            //Debug.Log(bunnyHop);
        }

        //bunnyGO.transform.position = new Vector3(location.x, location.y, location.z)    
        
    }

    public void ApplyForce(Vector2 force)
    {
        body.AddForce(force, ForceMode.Force);
    }

    public void Update()
    {
       // CheckEdges();
    }
    /*
    public void CheckEdges()
    {
        Vector2 velocity = body.velocity;
        if (transform.position.x > maximumPos.x || transform.position.x < minimumPos.x)
        {
            velocity.x *= -1;
        }
        if (transform.position.y > maximumPos.y || transform.position.y < minimumPos.y)
        {
            velocity.y *= -1;
        }
        body.velocity = velocity;
    }*/
}