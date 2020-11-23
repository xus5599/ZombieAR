using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100.0F;

    
    public Vector3 direccion = Vector3.zero;
    private Rigidbody rb;

    public GameObject ulti;
    public int powerup = 0;
    public Text textopowerup;

    public GameObject mirilla;

    float timeAux;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

      

        powerup = 0;
        textopowerup.text = powerup.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        float timeDif = Time.time - timeAux;

        //Movimiento y rotación del personaje.

        direccion = Vector3.zero;
       
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);
        if (direccion != Vector3.zero)
        {
            transform.forward = direccion;
        }

        rb.MovePosition(rb.position + direccion * speed * Time.deltaTime);

        //Power-up

        if (Input.GetKeyDown(KeyCode.G) && powerup > 0)
        {
            powerup--;
            textopowerup.text = powerup.ToString();

            Vector3 pos = new Vector3(transform.position.x  , transform.position.y + 1, transform.position.z  );
            GameObject clone = Instantiate(ulti, pos, Quaternion.identity) as GameObject;
            clone.SetActive(true);
        }

        //Ray cast para detectar enemigos al frente y asi, activar y desactivar la mirilla.

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position, fwd * 10, Color.red);

      
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit) && hit.transform.tag =="enemy")
        {
            mirilla.SetActive(true);
        }
        else
        {
            mirilla.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {    
        if (collision.transform.tag == "powerup")
        {
            powerup++;
            textopowerup.text = powerup.ToString();
            Destroy(collision.gameObject, 0);
        }
    }
    

    private void OnTriggerStay(Collider collision)
    {
        if (collision.transform.tag == "rango")
        {
            Destroy(collision.gameObject, 0);
        }
    }
}
