using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCTRL : MonoBehaviour
{
    // private float horizontalInput, verticalInput;
    // private float currentSteerAngle, currentBrakeForce;
    // private bool isBraking;
    // public int dano = 1;
    Rigidbody rb;
    public int speed;

    // public bool ativo = false;

    // [SerializeField] private float motorForce, brakeForce, maxSteerAngle;

    // [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    // [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    // [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            rb.AddTorque(new Vector3(0,0,-300) *speed, ForceMode.Force);
        }
        if(Input.GetKey(KeyCode.S)){
            rb.AddTorque(new Vector3(0,0,-300) *speed, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.D)){
            rb.AddTorque(new Vector3(0,0,-300) *speed, ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.A)){
            rb.AddTorque(new Vector3(0,0,-300) *speed, ForceMode.Acceleration);
        }

    }
}
