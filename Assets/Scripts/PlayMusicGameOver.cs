using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicGameOver : MonoBehaviour
{
    private GameObject player;

    AudioSource musicaNormal;
    private PlayerMovement playerMovementScript;
    
    private AudioSource crashSource;
    private float haMuerto = 1;
    public ParticleSystem playerExplosionParticles;
    //el haMuerto vale para que no se repita en bucle el sonido al morir
    public AudioClip gameOverSound;
    public AudioClip crashSound;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");

        musicaNormal = GetComponent<AudioSource>();
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        crashSource = GetComponent<AudioSource>();
       
        

    }

    // Update is called once per frame
    void Update()
    {
        //todo el lio de los if y el haMuerto es para que no repita los sonidos en bucle
        if (playerMovementScript.isDead)
        {
            haMuerto++;
        }

        if (playerMovementScript.isDead == true && haMuerto==2)
        {
            //parar musica fondo
            musicaNormal.Stop();
            //sonido nave explota
            crashSource.PlayOneShot(crashSound, 1f);
            //particulas al morir
            Instantiate(playerExplosionParticles, player.transform.position, playerExplosionParticles.transform.rotation);
            //iniciar musica gameover solo 1 vez
            crashSource.PlayOneShot(gameOverSound, 0.5f);
            Destroy(player);

        }
        
        if (haMuerto > 10)
        {
            haMuerto = 3;
        }
         
    }
}
