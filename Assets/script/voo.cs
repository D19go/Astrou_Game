using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class voo : MonoBehaviour
{
    public float giroCima = -2;
    public float giroBaixo = 2;
    public float giroEsq = 2;
    public float giroDir = -2;
    float forcaAtual;
    public float velocidadeMaxima;
    public float forca = 5;
    
    public bool voando = false;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
    
       

        if(Input.GetKey(KeyCode.W)){
            transform.Rotate( new Vector3(giroCima, 0, 0));
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Rotate( new Vector3(giroBaixo, 0, 0));
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Rotate( new Vector3(0, 0, giroEsq));
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Rotate( new Vector3(0, 0, giroDir));
        }

        if (Input.GetKeyDown(KeyCode.Space)){          
            voando = !voando;
            Debug.Log(voando);
        }

        if(voando == true){
            Debug.Log(voando);
            forcaAtual += forca;     
        }
    
        if(forcaAtual < velocidadeMaxima){                
            Vector3 forwardDirection = transform.forward;
            rb.AddForce(forwardDirection * forcaAtual, ForceMode.VelocityChange);
        } else{
            forcaAtual = forca;
        }

        
    }

}