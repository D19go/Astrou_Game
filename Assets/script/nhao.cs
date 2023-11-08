using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nhao : MonoBehaviour
{
    public GameObject bola;
    Camera mainCamera;
    Transform jogadorTransform;

    void Start()
    {
        mainCamera = Camera.main; // Obtém a câmera principal
        jogadorTransform = transform; // Obtenha a transformação do jogador
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CriarBolaELancar();
        }
    }

    void CriarBolaELancar()
    {
        // Calcule a posição de instanciamento da bola (um pouco acima do jogador)
        Vector3 posicaoDeInstanciamento = jogadorTransform.position + Vector3.up * 1.0f;

        GameObject nova_bola = Instantiate(bola, posicaoDeInstanciamento, Quaternion.identity);

        // Obtenha a direção olhando para o ponto em que a câmera está apontando
        Vector3 direcao = mainCamera.transform.forward;

        nova_bola.GetComponent<Rigidbody>().AddForce(direcao * 10000); // Ajuste a força conforme necessário
    }
}
