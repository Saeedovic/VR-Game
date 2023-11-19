using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever4 : MonoBehaviour
{
    
    public Light light3;
    public Light light4;

    
    private bool isUp = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("RightHand"))
        {
            
            if (isUp)
            {
                
                light3.color = Color.green;
                light4.color = Color.green;

                
                isUp = false;
            }
            else
            {
              
                isUp = true;
            }
        }
    }
}
