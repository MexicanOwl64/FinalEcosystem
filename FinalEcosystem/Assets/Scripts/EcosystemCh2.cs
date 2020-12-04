using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemCh2 : MonoBehaviour
{
    Mover2_6 m; // A Mover and an Attractor
    Attractor a;

    // Start is called before the first frame update
    void Start()
    {
        m = new Mover2_6();
        a = new Attractor();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 force = a.Attract(m.body); // Apply the attraction from the Attractor on the Mover
        Vector3 repelForce = a.Repelling(m.body);
        a.ApplyRepel(repelForce);
        m.ApplyForce(force);
        m.Update();
        a.Update();
    }
}



public class Attractor
{
    public Transform transform;
    public float mass;
    private Vector3 location;
    private float G;
    public Rigidbody body;
    private Vector3 minimumPos, maximumPos;
    private GameObject attractor;
    

    public Attractor()
    {
        attractor = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        attractor.GetComponent<SphereCollider>().enabled = true;

        attractor.AddComponent<Rigidbody>();
        body = attractor.GetComponent<Rigidbody>();
        body.useGravity = false;
        Renderer renderer = attractor.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Diffuse"));
        renderer.material.color = Color.red;

        body.mass = 20f;
        G = 9.8f;
    }

    public Vector3 Attract(Rigidbody m)
    {
        Vector3 force = body.position - m.position;
        float distance = force.magnitude;

        // Remember we need to constrain the distance so that our circle doesn't spin out of control
        distance = Mathf.Clamp(distance, 5f, distance);

        force.Normalize();
        float strength = G * (body.mass * m.mass) / (distance * distance);
        force *= strength;
        return force;
    }

    public Vector3 Repelling(Rigidbody m)
    {
        Vector3 repelForce = body.position + m.position;
        float distance = repelForce.magnitude;

        // Remember we need to constrain the distance so that our circle doesn't spin out of control
        distance = Mathf.Clamp(distance, 5f, 25f);

        repelForce.Normalize();
        float strength = G / (body.mass / m.mass) * (distance / distance);
        repelForce *= strength;
        return repelForce;
    }

    public void Update()
    {
        CheckEdges();
    }

    public void ApplyRepel(Vector3 repelForce)
    {
        body.AddForce(repelForce, ForceMode.Force);
    }

    public void CheckEdges()
    {
        Vector3 velocity = body.velocity;
        float mSpeed = 5f;
        if (transform.position.x > maximumPos.x || transform.position.x < minimumPos.x)
        {
            velocity.x *= mSpeed * Time.deltaTime;
        }
        if (transform.position.y > maximumPos.y || transform.position.y < minimumPos.y)
        {
            velocity.y *= mSpeed * Time.deltaTime;
        }
        if (transform.position.z > maximumPos.z || transform.position.z < minimumPos.z)
        {
            velocity.z *= mSpeed * Time.deltaTime;
        }
        body.velocity = velocity;
    }

}



public class Mover2_6
{
    // The basic properties of a mover class
    public Transform transform;
    public Rigidbody body;

    private Vector3 minimumPos, maximumPos;

    private GameObject mover;

    public Mover2_6()
    {
        mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        transform = mover.transform;
        mover.AddComponent<Rigidbody>();
        body = mover.GetComponent<Rigidbody>();
        body.GetComponent<SphereCollider>().enabled = true;
        body.useGravity = false;
        Renderer renderer = mover.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Diffuse"));
        renderer.material.color = Color.white;


        body.mass = 20;
        transform.position = new Vector3(5, 0,5); // Default location
        findWindowLimits();
    }

    public void ApplyForce(Vector3 force)
    {
        body.AddForce(force, ForceMode.Force);
    }

    public void Update()
    {
        CheckEdges();
    }

    public void CheckEdges()
    {
        Vector3 velocity = body.velocity;
        float mSpeed = 5f;
        if (transform.position.x > maximumPos.x || transform.position.x < minimumPos.x)
        {
            velocity.x *= mSpeed * Time.deltaTime;
        }
        if (transform.position.y > maximumPos.y || transform.position.y < minimumPos.y)
        {
            velocity.y *= mSpeed * Time.deltaTime;
        }
        if (transform.position.z > maximumPos.z || transform.position.z < minimumPos.z)
        {
            velocity.z *= mSpeed * Time.deltaTime;
        }
        body.velocity = velocity;
    }

    private void findWindowLimits()
    {
        
    }
}

