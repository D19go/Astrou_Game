using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ATKjumper : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int ForceJump; 
    
    [SerializeField] private GameObject besouro;
    public bool kpofty = false;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private NavMeshAgent bixinho;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pulou(){
        kpofty =! kpofty;
        Debug.Log("chamou");
    }
}
