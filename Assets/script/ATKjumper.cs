using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ATKjumper : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int ForceJump; 
    
    [SerializeField] private GameObject SPHEREatk;
    public bool kpofty = false;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private NavMeshAgent bixinho;
    [SerializeField] private float SpeedATK; 
    [SerializeField] private float SpeedMESH; 


    void Start(){
        kpofty = false;
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
        rb.AddForce(Vector3.up * ForceJump, ForceMode.Force);
        Debug.Log("vezes 2");
       
    }

    public void pulou(){
        
        kpofty =! kpofty;
        SPHEREatk.gameObject.SetActive(kpofty);
        Debug.Log("vezes");
        StartCoroutine(ligaMesh());
    }

    IEnumerator ligaMesh(){
        Debug.Log("vezes 3");
        yield return new WaitForSeconds(SpeedMESH);
        kpofty =! kpofty;
        SPHEREatk.gameObject.SetActive(kpofty);
        bixinho.enabled = true;
    }
}
