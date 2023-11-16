using UnityEngine;

public class FixaTP : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Certifique-se de que temos um Rigidbody
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            // Adicione um Rigidbody se não existir
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Tornar kinematic para evitar interações indesejadas
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Quando ocorre uma colisão, pare o objeto
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero; // Zerar também a velocidade angular
            rb.isKinematic = true;
        }

        // Você também pode adicionar outras lógicas aqui, se necessário
    }
}
