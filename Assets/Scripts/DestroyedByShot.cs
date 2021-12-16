using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedByShot : MonoBehaviour
{
    private AudioSource crashSoundSource;
    public AudioClip crashSoundClip;
    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
       
        crashSoundSource = GameObject.Find("Player").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("playerBeam"))
        {
            crashSoundSource.PlayOneShot(crashSoundClip, 1.0f);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
