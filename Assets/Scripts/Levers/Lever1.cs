using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    private bool isUp = false;

    private void OnTriggerStay(Collider other)
    {
        if (other is Collider)
        {
            if (isUp)
            {
                
                // Lever 1 does nothing 
                isUp = false;
            }
            else
            {
                
                isUp = true;
            }
        }
    }
}
