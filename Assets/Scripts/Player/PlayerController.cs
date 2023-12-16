using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    private CharacterController characterController;
    private float horizontal, vertical;
    private Vector3 Yvelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        // Apply the rotation to the direction
        direction = Quaternion.Euler(0, transform.eulerAngles.y, 0) * direction;

        if (direction.magnitude < 0.1f) return;

        // Use the Move method for custom movement
        characterController.Move(direction * speed * Time.deltaTime + Yvelocity);
    }
}