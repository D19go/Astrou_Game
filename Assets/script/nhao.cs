using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class nhao : NetworkBehaviour
{
    public GameObject bola;
    public GameObject bolaForte;
    public bool CanhaoPronto = false;
    public int Forca = 15000000;

    Camera mainCamera;

    void Start()
    {
        CanhaoPronto = false;
        mainCamera = Camera.main; // Obtém a câmera principal
    }

    void Update()
    {
        if(!IsOwner)
            return;
        
        
        if (Input.GetMouseButton(0))
        {
            CriarBolaELancar();
            FireServerRPC();
        }
        if (Input.GetMouseButtonDown(1))
        {
            CriarBolaForteELancar();
            FireServerRPC();
        }
    }

    [ServerRpc]
    void FireServerRPC(){
        FireClientRPC();
    }

    [ClientRpc]
    void FireClientRPC(){
        if(!IsOwner){
        CriarBolaForteELancar();
        CriarBolaELancar();
        }
    }
    void CriarBolaELancar()
    {
        GameObject nova_bola = Instantiate(bola, transform.position, Quaternion.identity);

        // Obter a direção olhando para o ponto em que a câmera está apontando
        Vector3 direcao = mainCamera.transform.forward;
    
        nova_bola.GetComponent<Rigidbody>().AddForce(direcao * Forca); // Ajuste a força conforme necessário
    }
    void CriarBolaForteELancar()
    {
        GameObject nova_bola = Instantiate(bolaForte, transform.position, Quaternion.identity);

        // Obter a direção olhando para o ponto em que a câmera está apontando
        Vector3 direcao = mainCamera.transform.forward;

        nova_bola.GetComponent<Rigidbody>().AddForce(direcao * Forca); // Ajuste a força conforme necessário
    }

    public void M1Concluida(bool ok){
        CanhaoPronto = true;
    }


}
