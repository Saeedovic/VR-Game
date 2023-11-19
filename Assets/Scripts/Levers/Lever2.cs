using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
    public Light light3;
    public Light light4;
    
    public float colorChangeCooldown = 1f;

    private bool isUp = false;
    private bool isRotating = false;
    private float lastColorChangeTime;
    private Quaternion originalRotation;

    public AudioSource audioSource;


    private void Start()
    {

        originalRotation = transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "HandTrigger" && !isRotating)
        {
            if (Time.time - lastColorChangeTime >= colorChangeCooldown)
            {
                if (isUp)
                {
                    Debug.Log("Triggered by: " + other.gameObject.name);

                    transform.rotation = Quaternion.Euler(-15f, 0f, 0f);

                    if (audioSource != null)
                    {
                        Debug.Log("Playing green audio");
                        audioSource.Play();
                    }
                    light3.color = Color.green;
                    light4.color = Color.green;
                    Debug.Log("Setting rotation to -5");



                    isUp = false;
                }
                else
                {
                    transform.rotation = originalRotation;

                    if (audioSource != null)
                    {
                        audioSource.Play();
                    }
                    light3.color = Color.red;
                    light4.color = Color.red;



                    isUp = true;
                }

                lastColorChangeTime = Time.time;
            }
        }
    }
}