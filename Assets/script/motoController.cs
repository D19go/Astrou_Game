using UnityEngine;

public class MotoController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle;
    private bool isBraking;
    [SerializeField] private bool ativo = false;

    public int dano = 1;
    public float motorForce = 1000f;
    public float brakeForce = 2000f;
    public float maxSteerAngle = 30f;

    public WheelCollider frontWheelCollider;
    public WheelCollider rearWheelCollider;

    public Transform frontWheelTransform;
    public Transform rearWheelTransform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CarroAtivo(bool CarroEstaAtivo)
    {
        ativo = CarroEstaAtivo;
    }

    private void Update()
    {
        if (!ativo)
            return;

        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Braking Input
        isBraking = Input.GetKey(KeyCode.Space);

        // Apply motor force and brake force to wheel colliders
        rearWheelCollider.motorTorque = verticalInput * motorForce;
        float currentBrakeForce = isBraking ? brakeForce : 0f;
        frontWheelCollider.brakeTorque = currentBrakeForce;
        rearWheelCollider.brakeTorque = currentBrakeForce;

        // Steer the wheels
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontWheelCollider.steerAngle = currentSteerAngle;

        // Update the wheel transforms for visual representation
        UpdateSingleWheel(frontWheelCollider, frontWheelTransform);
        UpdateSingleWheel(rearWheelCollider, rearWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        // Get the position and rotation of the wheel collider
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);

        // Apply the position and rotation to the visual wheel
        wheelTransform.rotation = rot * Quaternion.Euler(0, 0, 0); // Adjust rotation here
        wheelTransform.position = pos;
    }
}
