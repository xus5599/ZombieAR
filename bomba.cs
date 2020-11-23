using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{
    public float speed;
    public GameObject particula;
    private AudioSource sonido;
    public AudioClip disparo;
    public AudioClip explosion;
    // Start is called before the first frame update
    void Start()
    {
        sonido = GetComponent<AudioSource>();
        StartCoroutine("destroy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    IEnumerator destroy()
    {



        sonido.clip = disparo;
        sonido.Play();

        yield return new WaitForSeconds(2.3f);
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        GameObject clone = Instantiate(particula, pos, Quaternion.identity) as GameObject;
        clone.SetActive(true);
        sonido.clip = explosion;
        sonido.Play();
        Destroy(gameObject);
    }
   
}
