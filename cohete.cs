using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cohete : MonoBehaviour
{
    private AudioSource sonido;
    public AudioClip despegue;
    
    public GameObject cobete;
    public Transform barrelEnd;
    public ParticleSystem estela;
    public int misil;
    public int bulletSpeed;
    public float despawnTime = 3.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;
    
    public Text municion;
    // Start is called before the first frame update
    void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        shootAble = true;
    }
    public void lanzamiento()
    {
        if (shootAble && misil > 0)
        {
            shootAble = false;
            Shoot();
            StartCoroutine(ShootingYield());
            misil--;
        }
    }
    void Shoot()
    {
        var bullet = Instantiate(cobete, barrelEnd.position, barrelEnd.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        sonido.clip = despegue;
        sonido.Play();
        estela.Play();
        Destroy(bullet, despawnTime);
    }
}
