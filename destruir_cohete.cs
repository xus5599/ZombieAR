using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir_cohete : MonoBehaviour
{
    public ParticleSystem boom;
    public AudioClip explosion;
    public AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        sonido = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "terrain")
        {
            
            sonido.clip = explosion;
            sonido.Play();
            
            Destroy(gameObject, 0.9f);
            boom.Play();
        }
    }
}
