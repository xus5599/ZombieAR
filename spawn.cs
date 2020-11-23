using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject enemy;
    float timeAux;
    public float tiempo;
    public float x;
    public float y;
    public float random;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        timeAux = Time.time;
        random = Random.Range(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        float timeDif = Time.time - timeAux;
        //random = Random.Range(x , y);
        if (timeDif > random)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
            GameObject clone = Instantiate(enemy, pos, Quaternion.identity) as GameObject;
            clone.SetActive(true);
            clone.transform.parent = parent.transform;
            timeAux = Time.time;
            random = Random.Range(x, y);
        }
    }
}
