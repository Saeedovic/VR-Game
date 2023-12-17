using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel1 : MonoBehaviour
{
  
    public GameObject disabledWheel;
    public GameObject questionMark;

    public Light Light16;

    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("RedPipe"))
        {
            PipeCollision();
        }
    }

    private void PipeCollision()
    {
        
        gameObject.SetActive(false);
        questionMark.SetActive(false);
        
        if (disabledWheel != null)
        {
            disabledWheel.SetActive(true);
            Light16.color = Color.green;
            audioSource.Play();
        }

    }
}