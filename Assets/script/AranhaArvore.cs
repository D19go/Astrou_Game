using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AranhaArvore : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMesh;
    private GameObject player;
    public float velocidadeInimigo;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Aranha");
        navMesh.speed = velocidadeInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.destination = player.transform.position;

        if(Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            navMesh.speed = 0;
        }
    }
}
