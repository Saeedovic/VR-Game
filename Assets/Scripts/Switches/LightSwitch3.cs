using System.Collections;
using UnityEngine;

public class LightSwitch3 : MonoBehaviour
{
    public Light lightSwitchLight1;
    public Light lightSwitchLight2;
    public Light lightSwitchLight3;
    public Light lightSwitchLight4;
    public float rotationSpeed = 1f;
    public float colorChangeCooldown = 1f;

    private bool isUp = false;
    private float lastColorChangeTime;
    private Quaternion originalRotation;

    public AudioSource audioSource;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "HandTrigger" && Input.GetButtonDown("XRI_Right_TriggerButton") && Time.time - lastColorChangeTime >= colorChangeCooldown)
        {
            StartCoroutine(RotateSwitch());
            lastColorChangeTime = Time.time;
        }
    }

    IEnumerator RotateSwitch()
    {
        float elapsedTime = 0f;
        Quaternion targetRotation;

        if (isUp)
        {
            targetRotation = Quaternion.Euler(originalRotation.eulerAngles.x, originalRotation.eulerAngles.y, 0f);
        }
        else
        {
            targetRotation = Quaternion.Euler(-6f, originalRotation.eulerAngles.y, 0f);
        }

        while (elapsedTime < rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, elapsedTime / rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;

        if (audioSource != null)
        {
            Debug.Log("Playing audio");
            audioSource.Play();
        }
        lightSwitchLight1.color = isUp ? Color.red : Color.red;
        lightSwitchLight2.color = isUp ? Color.red : Color.red;
        lightSwitchLight3.color = isUp ? Color.red : Color.red;
        lightSwitchLight4.color = isUp ? Color.red : Color.red;


        isUp = !isUp;
    }
}