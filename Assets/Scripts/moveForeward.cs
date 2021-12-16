using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForeward : MonoBehaviour
{
    
    private PlayerMovement playerMovementScript;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovementScript != null)
        {
            if(playerMovementScript.isDead == false)
            {

                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
        

    }
}
