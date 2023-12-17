using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public float gravity = 9.8f; // reintroduced gravity
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

        direction = Quaternion.Euler(0, transform.eulerAngles.y, 0) * direction;

        if (direction.magnitude < 0.1f) return;

        // Apply gravity to the Yvelocity
        Yvelocity.y -= gravity * Time.deltaTime;

        // Ensure the player is grounded
        if (characterController.isGrounded && Yvelocity.y < 0)
        {
            Yvelocity.y = -0.5f;
        }

        characterController.Move(direction * speed * Time.deltaTime + Yvelocity);
    }
}