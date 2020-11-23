using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disparo_2 : MonoBehaviour
{
    public float tiempo;
    private AudioSource sonido;
    public AudioClip disparo;
    public AudioClip reload;
    public GameObject theBullet;
    public Transform barrelEnd;
    public ParticleSystem fuego;
    public float bulletSpeed;
    public float despawnTime = 3.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;
    public int cargador = 6;
    public int balas = 12;
    public Text municion;
    private float ScreenWidth;
    
    private void Start()
    {
        sonido = GetComponent<AudioSource>();
        ScreenWidth = Screen.width;
    }
    private void Update()
    {    
        municion.text = balas.ToString() ;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject, 0);

        }      
        if (collision.gameObject.tag == "terrain")
        {

            Destroy(gameObject,0);
        }
    }
    IEnumerator velocidad()
    {       
        yield return new WaitForSeconds(5f);
        bulletSpeed = bulletSpeed / 2;
    }
     IEnumerator bala()
    {
        yield return new WaitForSeconds(5f);
        waitBeforeNextShot = 0.25f;
        balas = 12;
        municion.text = balas.ToString();
    }
    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        shootAble = true;
    }
    void Shoot()
    {
        var bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        sonido.clip = disparo;
        sonido.Play();
        fuego.Play();
        Destroy(bullet, despawnTime);
    }
    public void gatillo()
    {
        if (shootAble && balas > 0)
        {
            shootAble = false;
            Shoot();
            StartCoroutine(ShootingYield());
            balas--;
        }
    }
    public void cragar()
    {

        balas = 12;
        sonido.clip = reload;
        sonido.Play();

    }
}
