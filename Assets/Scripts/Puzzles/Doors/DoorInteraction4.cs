using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction4 : MonoBehaviour
{
    public Camera vrCamera;
    public Transform player;
    public Vector3 newPlayerPosition = new Vector3(-0.358f, 2.455f, 11.095f);
    public Light light1;
    public Light light2;
    public Light light3;
    public Light light4;
  



    void OnTriggerEnter(Collider other)
    {
        if (light1.color == Color.green & light2.color == Color.green & light3.color == Color.green & light4.color == Color.green)
        {

            if (other.gameObject.name == "HandTrigger")
            {

                if (vrCamera != null)
                {
                    vrCamera.enabled = false;
                }


                if (player != null)
                {
                    player.position = newPlayerPosition;
                }


                if (vrCamera != null)
                {
                    vrCamera.enabled = true;
                }
            }
        }

    }
}
