using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField]
    private float maxBendAngle;
    [SerializeField]
    private float segDistance;

    [SerializeField, Range(-1f, 1f)]
    private float currentAngle;

    private Rigidbody2D rb;

    public float SegDistance
    { 
        get { return segDistance; } 
    }

    public float CurrentAngle
    {
        get { return maxBendAngle * currentAngle; }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ChangeAngle();

    }

    private void ChangeAngle()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(currentAngle < 1)
            currentAngle = currentAngle + .02f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (currentAngle > -1)
                currentAngle = currentAngle - .02f;
        }
    }

    public void BounceUp(Vector2 force, Vector2 position)
    {
        rb.AddForceAtPosition(force, position);
    }
}
