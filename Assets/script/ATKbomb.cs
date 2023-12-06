using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKbomb : MonoBehaviour
{

    [SerializeField] private float raycastDistance = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance))
        {
            // Verificar se o raio atingiu um objeto com a tag "Inimigo"
            if (hit.collider.CompareTag("Player"))
            {
                
            }
            /*else
            {
                // Lógica para lidar com outras colisões detectadas pelo raycast
                Debug.Log("Colisão detectada!");
            }*/
        }
    }
}
