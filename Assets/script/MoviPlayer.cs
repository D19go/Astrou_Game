using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class MoviPlayer : MonoBehaviour
{
    // int atacando = 0;
    public float pulo = 5f;

    public float velocidadeCorrendo = 10f; // Velocidade de corrida

    public float veloMovi = 0;
    bool NoAr = false;
    float mass;
    public bool Armado = false; 
    public bool Armado2 = false; 
    public Animator mover;
    Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        mass = rb.mass;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // public void equipado2(bool pegou2){
    //     Armado2 = pegou2;
    // }
    void Update()
    {
        // if(atacando == 1){
        //     return;
        // }

        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(hori,0,vert);
        direcao = direcao.normalized;
        direcao = transform.TransformDirection(direcao);
        float velocidade_x = direcao.x * veloMovi * Time.deltaTime * mass;
        float velocidade_z = direcao.z * veloMovi * Time.deltaTime * mass;

        rb.velocity = new Vector3(velocidade_x, rb.velocity.y, velocidade_z);

        transform.localRotation = Quaternion.Euler(0, Camera.main.transform.localEulerAngles.y, 0);


        if(Input.GetKey(KeyCode.W)){
            if (Input.GetKey(KeyCode.LeftShift)){
                rb.velocity = new Vector3(velocidade_x, rb.velocity.y, velocidade_z) * velocidadeCorrendo;
            }
        }   
         

  

        if(Input.GetKeyDown(KeyCode.Space) && !NoAr){
            GetComponent<Rigidbody>().AddForce(Vector3.up * pulo, ForceMode.Impulse);
            NoAr = true;
        }
    }

    // void AnimacaoAtaque(int num){
    //     atacando = num;
    // }

    

    void OnCollisionStay(Collision colisionPeC ){
        if(colisionPeC.gameObject.tag == "piso"){
            NoAr = false;
        }   
    }
    
}