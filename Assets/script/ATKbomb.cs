using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKbomb : MonoBehaviour
{

    [SerializeField] private UnityEngine.AI.NavMeshAgent bomber;
    [SerializeField] private GameObject particulas;
    [SerializeField] private float raycastDistance = 50f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int seg;
    [SerializeField] private SkinnedMeshRenderer mesha;
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
                Debug.Log("ray ok");
                bomber.enabled = false;
                StartCoroutine(cabooom());
            }
        }
    }

    IEnumerator cabooom(){
        particulas.SetActive(true);
        mesha.enabled = false;
        yield return new WaitForSeconds(seg);
        Destroy(gameObject);
    }
}
