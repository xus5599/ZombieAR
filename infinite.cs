using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinite : MonoBehaviour
{
    public GameObject nuque;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bala")
        {
            nuque.SetActive(true);
            Destroy(gameObject);
        }
    }
    
}
