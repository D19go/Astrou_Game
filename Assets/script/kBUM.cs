using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kBUM : MonoBehaviour
{
    [SerializeField] private GameObject bum;
    [SerializeField] private GameObject area;
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

    void OnCollisionEnter(Collision bateukbum){
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero; // Zerar também a velocidade angular
            rb.isKinematic = true;
        }
        StartCoroutine(kbom());
    }

    IEnumerator kbom(){
        rb = null;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        bum.SetActive(true);
        area.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        area.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        bum.SetActive(false);
        
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    /*void kbom(){
        bum.SetActive(true);wwwwwww
        area.SetActive(true);
        Invoke("desKBUM", 1.5f);
    }

    void desKBUM(){
        bum.SetActive(false);
        area.SetActive(false);
    }*/
}
