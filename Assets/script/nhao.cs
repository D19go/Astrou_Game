using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class nhao : MonoBehaviour
{
    public GameObject bola;
    public GameObject bolaForte;
    public bool CanhaoPronto = false;
    public int Forca = 150000;
    bool CamAtual = true;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera mainCamera2;

    // Variáveis para controle de disparos
    public float timeBetweenShotsMouse0 = 0.5f;  // Ajuste o tempo entre os disparos para o botão do mouse 0
    public float timeBetweenShotsMouse1 = 0.5f;  // Ajuste o tempo entre os disparos para o botão do mouse 1
    private float timeSinceLastShotMouse0, timeSinceLastShotMouse1;

    void Start()
    {
        
        mainCamera = Camera.main; // Obtém a câmera principal
        timeSinceLastShotMouse0 = 0f;
        timeSinceLastShotMouse1 = 0f;
    }

    void Update()
    {
        if (!CanhaoPronto)
            return;

        // Atualizar contadores de tempo
        timeSinceLastShotMouse0 += Time.deltaTime;
        timeSinceLastShotMouse1 += Time.deltaTime;

        if (Input.GetMouseButton(0) && timeSinceLastShotMouse0 >= timeBetweenShotsMouse0)
        {
            CriarBolaELancar();
            timeSinceLastShotMouse0 = 0f;  // Resetar o contador de tempo
        }

        if (Input.GetMouseButtonDown(1) && timeSinceLastShotMouse1 >= timeBetweenShotsMouse1)
        {
            CriarBolaForteELancar();
            timeSinceLastShotMouse1 = 0f;  // Resetar o contador de tempo
        }
    }

    void CriarBolaELancar()
    {   
        if(CamAtual){ 
            GameObject nova_bola = Instantiate(bola, transform.position, Quaternion.identity);
            // Obter a direção olhando para o ponto em que a câmera está apontando
            Vector3 direcao = mainCamera.transform.forward;
            // Rotacionar a bola para que ela aponte para a direção correta
            Quaternion rotacao = Quaternion.LookRotation(direcao);
            nova_bola.transform.rotation = rotacao * Quaternion.Euler(90, 0, 0);
            nova_bola.GetComponent<Rigidbody>().AddForce(direcao * Forca); // Ajuste a força conforme necessário
        }else{
            GameObject nova_bola = Instantiate(bola, transform.position, Quaternion.identity);
            // Obter a direção olhando para o ponto em que a câmera está apontando
            Vector3 direcao = mainCamera2.transform.forward;
            // Rotacionar a bola para que ela aponte para a direção correta
            Quaternion rotacao = Quaternion.LookRotation(direcao);
            nova_bola.transform.rotation = rotacao * Quaternion.Euler(90, 0, 0);
            nova_bola.GetComponent<Rigidbody>().AddForce(direcao * Forca); // Ajuste a força conforme necessário
        }


    }

    void CriarBolaForteELancar()
    {   
        if(CamAtual){
            GameObject nova_bola = Instantiate(bolaForte, transform.position, Quaternion.identity);
            // Obter a direção olhando para o ponto em que a câmera está apontando
            Vector3 direcao = mainCamera.transform.forward;
            // Rotacionar a bola para que ela aponte para a direção correta
            Quaternion rotacao = Quaternion.LookRotation(direcao);
            nova_bola.transform.rotation = rotacao * Quaternion.Euler(90, 0, 0);
            nova_bola.GetComponent<Rigidbody>().AddForce(direcao * Forca); // Ajuste a força conforme necessário
        }else{
            GameObject nova_bola = Instantiate(bolaForte, transform.position, Quaternion.identity);
            // Obter a direção olhando para o ponto em que a câmera está apontando
            Vector3 direcao = mainCamera2.transform.forward;
            // Rotacionar a bola para que ela aponte para a direção correta
            Quaternion rotacao = Quaternion.LookRotation(direcao);
            nova_bola.transform.rotation = rotacao * Quaternion.Euler(90, 0, 0);
            nova_bola.GetComponent<Rigidbody>().AddForce(direcao * Forca); // Ajuste a força conforme necessário
        }
    }

    public void M0Concluida(bool ok)
    {
        CanhaoPronto = true;
    }

    public void M1Concluida(bool ok)
    {
        CanhaoPronto = true;
    }

    public void CamMain(bool cams){
        CamAtual = cams;
    }
}
