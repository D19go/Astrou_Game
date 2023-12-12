using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoSCam : MonoBehaviour

{
    public GameObject bolaForte;
    public int Forca = 150000;
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            lancarBola();
        }
    }

    void lancarBola(){
        GameObject nova_bola = Instantiate(bolaForte, transform.position, Quaternion.identity);
        Vector3 direcao = transform.forward;
        Quaternion rotacao = Quaternion.LookRotation(direcao);
        nova_bola.transform.rotation = rotacao * Quaternion.Euler(90, 0, 0);
        nova_bola.GetComponent<Rigidbody>().AddForce(direcao * Forca * Time.deltaTime, ForceMode.VelocityChange); // Ajuste a força conforme necessário
        
    }
}
