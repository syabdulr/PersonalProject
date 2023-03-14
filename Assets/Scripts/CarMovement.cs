using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float acceleration = 500f;
    public float breakingForce = 200f;
    public float maxTurnAngle = 15f;

    float currentAcceleration = 0f;
    float currentBreakForce = 0f;
    float currentTurnAngle = 0f;

    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakingForce;
        }
        else
        {
            currentBreakForce = 0f;
        }
        transform.position = transform.position +
            new Vector3(currentAcceleration * Time.deltaTime, 1 * Time.deltaTime);

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        //need to use same wheel component like in tutorial.. 9:54
        //cannot apply basic movement with this solution;
        //transform.localRotation = currentTurnAngle;
    }
}
