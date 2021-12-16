using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class enemyShoot : MonoBehaviour
{
    private PlayerMovement playerMovementScritp;
    public GameObject foeBeam;
    public AudioClip foeLaserSound;
    private AudioSource foeLaserShotSound;
    Stopwatch timer;
    
    public float cooldown = 0.35f;

    // Start is called before the first frame update
    void Start()
    {
        foeLaserShotSound = GetComponent<AudioSource>();
        playerMovementScritp = GameObject.Find("Player").GetComponent<PlayerMovement>();
        timer = new Stopwatch();
        timer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(playerMovementScritp.isDead == false)
        {
            if (timer.ElapsedMilliseconds / 1000f > cooldown )
            {
                
         
                Instantiate(foeBeam, transform.position, foeBeam.transform.rotation);
                foeLaserShotSound.PlayOneShot(foeLaserSound, 1.0f);
                timer.Restart();
            }
        }


        
    }
}
