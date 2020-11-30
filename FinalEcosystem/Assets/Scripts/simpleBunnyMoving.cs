using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleBunnyMoving : MonoBehaviour
{
    public Transform Predator;
    float mSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Predator.position);
        transform.Translate(0f, 0.0f, -mSpeed * Time.deltaTime);
    }
}
