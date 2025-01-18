using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField, Tooltip("This is the maximum bend angle between segments.")]
    private float maxBendAngle;
    [SerializeField, Tooltip("This is the default distance between segments.")]
    private float segDistance;

    [SerializeField, Tooltip("This is the multiplier of driving force, compared to the boucing force.")]
    private float drivingForceMult;
    private Vector2 drivingForceScale;

    [SerializeField, Range(-1f, 1f), Tooltip("This is the normalized bend angle scale between segments.")]
    private float currentAngleScale;

    private Rigidbody2D rb;


    public float MaxDrivingForce
    { 
        get { return drivingForceMult; } 
    }

    public float SegDistance
    { 
        get { return segDistance; } 
    }

    public float CurrentAngle
    {
        get { return maxBendAngle * currentAngleScale; }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        drivingForceScale = Vector2.zero;
    }

    public void ChangeAngle(float delta)
    {
        currentAngleScale += delta;

        currentAngleScale = currentAngleScale > 1 ? 1 : currentAngleScale;
        currentAngleScale = currentAngleScale < -1 ? -1 : currentAngleScale;
    }

    public void SetDrivingForce(float deltaForceScale)
    {
        drivingForceScale.x = deltaForceScale;
        drivingForceScale.y = 0;

        drivingForceScale.x = drivingForceScale.x > 1 ? 1 : drivingForceScale.x;
        drivingForceScale.x = drivingForceScale.x < -1 ? -1 : drivingForceScale.x;
    }

    public void BounceUp(Vector2 boucingForce, Vector2 position)
    {
        rb.velocity = new Vector2(rb.velocity.x * 0.1f, rb.velocity.y);

        Vector2 totalForce = boucingForce + boucingForce.magnitude * drivingForceScale * drivingForceMult;

        rb.AddForceAtPosition(totalForce, position);
    }
}
