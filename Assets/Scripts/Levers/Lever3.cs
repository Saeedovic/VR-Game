using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever3 : MonoBehaviour
{
    public Light light2;
    public Light light3;

    public float colorChangeCooldown = 1f;

    private bool isUp = false;
    private float lastColorChangeTime;
    private Quaternion originalRotation;
    public AudioSource audioSource;

    private Vector3 greenRotation = new Vector3(352, 358, 3);


    private void Start()
    {
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        
        Vector3 currentRotation = transform.rotation.eulerAngles;

       
        if (!isUp && Vector3.Distance(currentRotation, greenRotation) < 1)
        {
            ActivateLights();
        }
        else if (isUp && Vector3.Distance(currentRotation, originalRotation.eulerAngles) < 1)
        {
            DeactivateLights();
        }
    }

    private void ActivateLights()
    {
        if (Time.time - lastColorChangeTime >= colorChangeCooldown)
        {
            Debug.Log("Setting lights to green");
            light2.color = Color.green;
            light3.color = Color.green;

            if (audioSource != null)
            {
                audioSource.Play();
            }

            isUp = true;
            lastColorChangeTime = Time.time;
        }
    }

    private void DeactivateLights()
    {
        if (Time.time - lastColorChangeTime >= colorChangeCooldown)
        {
            Debug.Log("Setting lights to red");
            light2.color = Color.red;
            light3.color = Color.red;

            if (audioSource != null)
            {
                audioSource.Play();
            }

            isUp = false;
            lastColorChangeTime = Time.time;
        }
    }
}