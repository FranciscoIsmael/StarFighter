using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float topBound = 55;
    public float lowerBound = -55;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound)
        {
           Destroy(gameObject);
        }
        if (transform.position.y < lowerBound)
        {
           Destroy(gameObject);
        }
        if(transform.position.x > topBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.x < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
