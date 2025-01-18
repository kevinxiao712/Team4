using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSegment : MonoBehaviour
{
    [SerializeField, Tooltip("0 means rotating center, positive number means front body, negative number means back body.")]
    private int segOrder;

    private Vector2 previousPosition;
    private Vector2 currentPosition;
    private Vector2 velocity;

    private FishController fishController;


    private void Awake()
    {
        fishController = GetComponentInParent<FishController>();
    }

    private void Start()
    {
        transform.localPosition = CalLocalPosition();
        transform.localRotation = Quaternion.Euler(0, 0, fishController.CurrentAngle * segOrder);

        previousPosition = transform.position;
        currentPosition = transform.position;
        velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        transform.localPosition = CalLocalPosition();
        transform.localRotation = Quaternion.Euler(0, 0, fishController.CurrentAngle * segOrder);

        currentPosition = transform.position;
        velocity = (currentPosition - previousPosition) / Time.deltaTime;
        previousPosition = currentPosition;
    }


    private Vector2 CalLocalPosition()
    {
        Vector2 newVector = Vector2.zero;

        for (int i = 0; i < Mathf.Abs(segOrder); i++)
        {
            newVector += 
                fishController.SegDistance * 
                new Vector2(
                    Mathf.Cos((i + 1) * fishController.CurrentAngle * Mathf.Deg2Rad) * Mathf.Sign(segOrder), 
                    Mathf.Sin((i + 1) * fishController.CurrentAngle * Mathf.Deg2Rad));
        }

        return newVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Vector2 bounceForce = fishController.BouncingForceScale * new Vector2(velocity.x, -velocity.y);

            fishController.BounceUp(bounceForce, transform.position);
        }
    }
}
