using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankiCTRL : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private int forceSpeed;
    [SerializeField] private int RotacaoTanque;
    [SerializeField] private float giroTorreta;
    [SerializeField] private float ergueTorreta;
    [SerializeField] private GameObject torretaCorpo;
    [SerializeField] private GameObject CanhaoTorreta;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            Vector3 forwardDirection = transform.forward;
            rb.AddForce(forwardDirection * forceSpeed, ForceMode.VelocityChange);
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(0,-RotacaoTanque,0);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(0,RotacaoTanque,0);
        }

        if(Input.GetKey(KeyCode.S)){
            Vector3 forwardDirection = transform.forward;
            rb.AddForce(forwardDirection * -forceSpeed, ForceMode.VelocityChange);
        }

        if(Input.GetKey(KeyCode.Q)){
            torretaCorpo.transform.Rotate(0,0,-giroTorreta);
        }
        if(Input.GetKey(KeyCode.E)){
            torretaCorpo.transform.Rotate(0,0,giroTorreta);
        }

        if(Input.mouseScrollDelta.y > 0){
            CanhaoTorreta.transform.Rotate(ergueTorreta,0,0);
        }
        if(Input.mouseScrollDelta.y < 0){
            CanhaoTorreta.transform.Rotate(-ergueTorreta,0,0);
        }
    }
}
