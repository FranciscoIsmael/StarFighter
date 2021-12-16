using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBehavior : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    public float speed = 20;
    public float sideSpeed = 50;
    private float limLateral = 28;
    private float Rlim = 26;
    private float Llim = -26;
    Vector3 currentOffset;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        currentOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovementScript.isDead == false)
        {

            transform.Translate(Vector3.right * sideSpeed * Time.deltaTime);

            if (transform.position.x < Llim || transform.position.x > Rlim)
            {
                sideSpeed = sideSpeed * -1;
            }
        }


    }
}
