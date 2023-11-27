using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch3 : MonoBehaviour
{

    public float rotationSpeed = 1f;
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

                    transform.rotation = Quaternion.Euler(-245f, 0f, 0f);

                    if (audioSource != null)
                    {
                        Debug.Log("Playing audio");
                        audioSource.Play();
                    }
                    isUp = false;
                }
                else
                {
                    transform.rotation = originalRotation;

                    if (audioSource != null)
                    {
                        audioSource.Play();
                    }





                    isUp = true;
                }

                lastColorChangeTime = Time.time;
            }
        }
    }
}