using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeamMovement : MonoBehaviour
{
    public int speed = 80;
    private Transform playerTransform;
    

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0, Vector3.up.y * speed * Time.deltaTime, 0);
    }
}
