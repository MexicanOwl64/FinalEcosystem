using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public Transform Prey;
    float mSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Prey.position);
        transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);
    }
}