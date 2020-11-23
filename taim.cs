using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taim : MonoBehaviour
{

    public void encontrado()
    {
        Time.timeScale = 1f;
    }

   
    public void perdido()
    {
        Time.timeScale = 0f;
    }
}
