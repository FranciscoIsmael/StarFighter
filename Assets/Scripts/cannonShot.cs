using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class cannonShot : MonoBehaviour
{
    private AudioSource laserShotSound;
    private PlayerMovement playerMovementScript;
    public AudioClip laserSound;
    public GameObject playerBeam;
    public GameObject[] playerBeamPool;
    private int maxRange;
  
    Stopwatch timer;
    public float cooldown = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        laserShotSound = GameObject.Find("Player").GetComponent<AudioSource>();
        timer = new Stopwatch();
        timer.Start();
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        maxRange = playerBeamPool.Length - 1;
        playerBeam = playerBeamPool[Random.Range(0, maxRange)];
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(playerMovementScript.isDead == false)
        {
            //disparar
            if (Input.GetKeyDown(KeyCode.Space) && timer.ElapsedMilliseconds / 1000f > cooldown)
            {
                
                
                //instancia el laser
                Instantiate(playerBeam, transform.position, transform.rotation);
                //hace el sonido de disparo
                laserShotSound.PlayOneShot(laserSound, 1.0f);
                //resetea el cooldown
                timer.Restart();
            }
        }
       
    }
}
