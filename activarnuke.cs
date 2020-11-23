using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarnuke : MonoBehaviour
{
    public GameObject bomba;
        public GameObject boton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
       
    }
    public void onclick()
    {
        Vector3 pos = new Vector3(27.90722f, 432.0121f, -45.20981f);
        GameObject clone = Instantiate(bomba, pos, Quaternion.identity) as GameObject;
        clone.SetActive(true);
        boton.SetActive(false);
    }
}
