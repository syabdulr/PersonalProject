using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    WheelCollider frontRight, frontLeft, backRight, backLeft;
    [SerializeField]
    Transform frontRightTransform, frontLeftTransform, backRightTransform, backLeftTransform;
    public float acceleration = 500f;
    public float breakingForce = 200f;
    public float maxTurnAngle = 15f;

    float currentAcceleration = 0f;
    float currentBreakForce = 0f;
    float currentTurnAngle = 0f;

    private void Awake()
    {
        var com = gameObject.GetComponent<Rigidbody>();
        com.centerOfMass += new Vector3(0, -1f, 0);
    }
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
        //applying acceleration to front wheels
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        //applying break force to all wheels
        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backLeft.motorTorque = currentBreakForce;
        backRight.motorTorque = currentBreakForce;

        //steering
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        RotateWheel(frontLeft, frontLeftTransform);
        RotateWheel(frontRight, frontRightTransform);

        RotateWheel(backLeft, backLeftTransform);
        RotateWheel(backRight, backRightTransform);

    }
    void RotateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);
        trans.position = position;
        trans.rotation = rotation;
    }
}
