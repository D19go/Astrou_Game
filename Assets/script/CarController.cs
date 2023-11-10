using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentBrakeForce;
    private bool isBraking;
    public int dano = 1;
    Rigidbody rb;

    public bool ativo = false;

    [SerializeField] private float motorForce, brakeForce, maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    public void CarroAtivo(bool CarroEstaAtivo)
    {
        ativo = CarroEstaAtivo;
    }

    private void Update()
    {
        if (ativo == false)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            transform.rotation = new  Quaternion(0,transform.rotation.y,0, transform.rotation.w);
            gameObject.GetComponent<VidaGeral>().TomaToma(dano);
        }
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBraking = Input.GetKey(KeyCode.Space);

        rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentBrakeForce = isBraking ? brakeForce : 0f;

        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;

        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;

        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);

        // transform.rotation = new  Quaternion(0f,transform.rotation.y,transform.rotation.z, transform.rotation.w);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
