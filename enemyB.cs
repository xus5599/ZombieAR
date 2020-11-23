using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyB : MonoBehaviour
{
    NavMeshAgent miNavMesh;
    public GameObject destino;
    public int vidas;

    public GameObject nuke;
    public GameObject slow;
    

    public float powerup;
    public float animor;
    public int morir;
    private Animator animate;
    public bool mort;
    public bool mort1;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        miNavMesh = GetComponent<NavMeshAgent>();
        vidas = 1;

        morir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        animate.SetBool("muerte", mort);
        animate.SetBool("muerte1", mort1);
        float distancia = Vector3.Distance(transform.position, destino.transform.position);

        if (distancia > 0.0f)
        {
            miNavMesh.SetDestination(destino.transform.position);
        }

        if (vidas == 0)
        {

            if (morir == 1)
            {
                morir = 0;

                powerup = Random.Range(0f, 100f);

                if (powerup >= 99f && powerup < 100)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
                    GameObject clone = Instantiate(nuke, pos, Quaternion.identity) as GameObject;
                    clone.SetActive(true);
                }
                else if (powerup >= 91 && powerup < 93)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
                    GameObject clone = Instantiate(slow, pos, Quaternion.identity) as GameObject;
                    clone.SetActive(true);
                }
            }
            StartCoroutine("muerte");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bala")
        {
            vidas--;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.transform.tag == "rango")
        {
            vidas--;
        }
    }
    IEnumerator muerte()
    {
        

            animor = Random.Range(0f, 100f);

            if (animor >= 50f && animor < 100)
            {
            mort = true;
            }
            else if (animor >= 0 && animor < 50)
            {
            mort1 = true;
            }
           

       
        yield return new WaitForSeconds(1.3f);

        Destroy(gameObject);
    }
}


