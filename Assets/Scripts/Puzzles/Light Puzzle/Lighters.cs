using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighters : MonoBehaviour
{
    public bool isOn = false;

    
    void Update()
    {
        if (isOn)
        {
            
            GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            
            GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
