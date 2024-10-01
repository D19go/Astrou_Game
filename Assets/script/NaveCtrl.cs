using System.Collections;
using UnityEngine;

public class NaveCtrl : MonoBehaviour
{
    bool voando = false;
    public int speedFly = 10;
    public int MoveGiro = 1;
    public int SDpower = 5;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        voando = false;
        // Calcula o offset inicial da câmera em relação à nave
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("m");
            voando = !voando;
        }

        if (voando)
        {
            transform.Translate(0, 0, speedFly * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-(MoveGiro * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(MoveGiro * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -(MoveGiro * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, MoveGiro * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(0, SDpower * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(0, -(SDpower * Time.deltaTime), 0);
        }

    }
}
