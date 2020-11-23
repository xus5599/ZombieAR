using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow : MonoBehaviour
{
    public float tiempo;
    public GameObject reloj;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bala")
        {
            tiempo = Time.timeScale = 0.5f;
            StartCoroutine("time");
            reloj.SetActive(true);
        }
    }
    IEnumerator time()
    { transform.position = new Vector3(-1000f, -1000f - 1000f);
        yield return new WaitForSeconds(5f);
        tiempo = Time.timeScale = 1f;
        reloj.SetActive(false);
        Destroy(gameObject);
    }
}
