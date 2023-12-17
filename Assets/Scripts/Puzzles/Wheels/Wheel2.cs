using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel2: MonoBehaviour
{

    public GameObject disabledWheel;
    public GameObject questionMark;

    public Light Light16;

    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("BlackPipe"))
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