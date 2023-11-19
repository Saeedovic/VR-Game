using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever4 : MonoBehaviour
{
    public GameObject leverObject; 
    public Light light3;
    public Light light4;
    public float rotationSpeed = 1f;
    public float colorChangeCooldown = 1f;

    private bool isUp = false;
    private bool isRotating = false;
    private float lastColorChangeTime;

    private void Update()
    {
        if (isRotating)
        {
            
            return;
        }
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

                    light3.color = Color.green;
                    light4.color = Color.green;

                   
                   /* StartCoroutine(RotateLever(-5f));*/
                    isUp = false;
                }
                else
                {
                    light3.color = Color.red;
                    light4.color = Color.red;

                   
                   // StartCoroutine(RotateLever(0f));
                    isUp = true;
                }

                lastColorChangeTime = Time.time;
            }
        }
    }

   /* private IEnumerator RotateLever(float targetRotation)
    {
        isRotating = true;
        Quaternion startRotation = leverObject.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(targetRotation, 0f, 0f);
        float startTime = Time.time;

        while (Time.time - startTime <= rotationSpeed)
        {
            float t = (Time.time - startTime) / rotationSpeed;
            leverObject.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }

        leverObject.transform.rotation = endRotation; 
        isRotating = false;
    }*/
}
