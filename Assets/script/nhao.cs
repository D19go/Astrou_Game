using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nhao : MonoBehaviour
{
    public GameObject bola;

    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Obtém a câmera principal
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
        GameObject nova_bola = Instantiate(bola, transform.position, Quaternion.identity);

        // Obter a direção olhando para o ponto em que a câmera está apontando
        Vector3 direcao = mainCamera.transform.forward;

        nova_bola.GetComponent<Rigidbody>().AddForce(direcao * 15000000 * Time.deltaTime); // Ajuste a força conforme necessário
    }
}
