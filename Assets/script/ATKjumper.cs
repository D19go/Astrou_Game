using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ATKjumper : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int ForceJump; 
    [SerializeField] private int ForceBackDash; 

    [SerializeField] private Rigidbody rb;
    [SerializeField] private NavMeshAgent bixinho;
    [SerializeField] private float SpeedATK; 
    [SerializeField] private float SpeedMESH; 
    [SerializeField] private int dano;
    [SerializeField] private GameObject Jogador;
    
    private bool atacou = false;


    void Start(){
        rb = GetComponent<Rigidbody>();
        
    }

    void OnTriggerEnter(Collider outro){
        if(outro.gameObject.tag == "Player"){
            StartCoroutine(atkPulando());
        }
    }


    IEnumerator atkPulando(){
        yield return new WaitForSeconds(SpeedATK);
        bixinho.enabled = false;
        anim.SetTrigger("Jumpe");
        rb.AddForce(Vector3.up * ForceJump * Time.deltaTime, ForceMode.Impulse);
        Debug.Log("vezes 2");
        StartCoroutine(ligaMesh());
       
    }

    IEnumerator ligaMesh(){
        Debug.Log("vezes 3");
        yield return new WaitForSeconds(SpeedMESH);
        rb.AddForce(Vector3.back * ForceBackDash * Time.deltaTime, ForceMode.Impulse);
        bixinho.enabled = true;
        if (Jogador != null)
        {
            Jogador.GetComponent<VidaPlayer>().TomaToma(dano);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Jogador = collision.gameObject;
        }
    }
}
