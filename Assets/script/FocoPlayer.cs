using System.Collections;
using UnityEngine;

public class FocoPlayer : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMesh;
    GameObject player;
    public float velocidadeInimigo;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (navMesh != null && player != null)
        {
            if (navMesh.isOnNavMesh) // Verifica se o NavMeshAgent está no NavMesh
            {
                navMesh.destination = player.transform.position;

                if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
                {
                    navMesh.speed = 0;
                }

                // Ajuste para alinhar o objeto pai com o jogador
                transform.LookAt(player.transform);
            }
            else
            {
               
            }
        }
    }
}
