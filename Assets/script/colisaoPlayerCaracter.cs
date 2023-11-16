using UnityEngine;

public class colisaoPlayerCarater : MonoBehaviour
{
    public float raycastDistance = 50f;
    public Transform fora;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        // Lançar um raio para a frente do objeto
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance))
        {
            // Verificar se o raio atingiu um objeto com a tag "Inimigo"
            if (hit.collider.CompareTag("TestOBJ"))
            {
                // Mover o jogador para a posição especificada por "fora"
                characterController.enabled = false; 
                transform.position = fora.position;
                characterController.enabled = true; 
            }
            /*else
            {
                // Lógica para lidar com outras colisões detectadas pelo raycast
                Debug.Log("Colisão detectada!");
            }*/
        }
    }
}
