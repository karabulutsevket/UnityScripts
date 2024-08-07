using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 2.0f;

    public Camera mainCamera;

    private Quaternion originalRotation;

    void Start()
    {
        // Save the original rotation of the player body . 
        originalRotation = playerBody.rotation;
    }


    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert the screen coordinates to world coordinates
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);

            // Calculate the direction from the player to the mouse position
            Vector3 direction = pointToLook - playerBody.position;
            direction.y = 0; // Keep the player body rotation on the horizontal plane

            // Rotate the player body to face that direction
            playerBody.rotation = Quaternion.LookRotation(direction);
        }
    }

}
