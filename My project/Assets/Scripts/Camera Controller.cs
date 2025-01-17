using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 20, 0);   // Offset of the camera relative to the player

    private void Update()
    {
        if (player != null)
        {
            // Update the camera's position while keeping the Z-axis fixed
            transform.position = new Vector3(
                player.position.x + offset.x,
                player.position.y + offset.y,
                transform.position.z // Maintain the camera's original Z position
            );
        }
    }
    }
