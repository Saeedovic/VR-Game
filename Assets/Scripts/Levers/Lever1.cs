using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1: MonoBehaviour
{
    public Light light1;
    public Light light3;
    public Light light4;

    public float colorChangeCooldown = 1.5f;

    private bool isUp = false;
    private float lastColorChangeTime;
    private Quaternion originalRotation;
    public AudioSource audioSource;


    private Vector3 greenRotation = new Vector3(352, 358, 3);

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    public void Update()
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

            if (audioSource != null)
            {
                audioSource.Play();
            }

            Debug.Log("Setting lights to green");
            light1.color = Color.green;
            light3.color = Color.green;
            light4.color = Color.green;


            isUp = true;
            lastColorChangeTime = Time.time;
        }
    }

    private void DeactivateLights()
    {
        if (Time.time - lastColorChangeTime >= colorChangeCooldown)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            Debug.Log("Setting lights to red");
            light1.color = Color.red;
            light3.color = Color.red;
            light4.color = Color.red;


            isUp = false;
            lastColorChangeTime = Time.time;
        }
    }
}