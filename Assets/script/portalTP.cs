using UnityEngine;

public class portalTP : MonoBehaviour
{
    public GameObject jogador;
    public Transform fora;
    private CharacterController characterController;

    void Start()
    {
        characterController = jogador.GetComponent<CharacterController>();
        
    }

    void OnTriggerEnter(Collider colidiu)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (colidiu.CompareTag("Player"))
        {
            // Mover o jogador para a posição especificada por "fora"
            characterController.enabled = false; // Desativar temporariamente o CharacterController
            jogador.transform.position = fora.position;
            characterController.enabled = true; // Reativar o CharacterController
        }
    }
}
