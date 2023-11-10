using System.Collections;
using UnityEngine;

public class NaveCtrl : MonoBehaviour
{
    bool voando = false;
    public int speedFly = 10;
    public int MoveGiro = 1;
    public int SDpower = 5;

    Rigidbody rb;

    public Transform naveTransform; // Referência à transformação da nave
    public Transform cameraTransform; // Referência à transformação da câmera

    private Vector3 cameraOffset; // Offset inicial da câmera em relação à nave

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Calcula o offset inicial da câmera em relação à nave
        cameraOffset = cameraTransform.position - naveTransform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            voando = !voando;
        }

        if (voando)
        {
            naveTransform.Translate(0, 0, speedFly * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            naveTransform.Rotate(-(MoveGiro * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            naveTransform.Rotate(MoveGiro * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            naveTransform.Rotate(0, 0, -(MoveGiro * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            naveTransform.Rotate(0, 0, MoveGiro * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            naveTransform.Translate(0, SDpower * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            naveTransform.Translate(0, -(SDpower * Time.deltaTime), 0);
        }

        // Atualiza a posição da câmera para seguir a nave, mas sem girar lateralmente
        cameraTransform.position = naveTransform.position + cameraOffset;
    }
}
