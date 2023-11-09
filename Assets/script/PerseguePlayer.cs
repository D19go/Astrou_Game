using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguePlayer : MonoBehaviour
{
    public float velocidade = 2f;
    private Rigidbody BadBugRG;
    public GameObject Player;
    public int dano = 10;

    void Start()
    {
        BadBugRG = GetComponent<Rigidbody>();
        BadBugRG.freezeRotation = true;
        Player = GameObject.FindWithTag("ArvoreMae");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direcao = (Player.transform.position - transform.position).normalized;

        // Rotaciona o inimigo na direção do movimento
        transform.LookAt(transform.position + direcao);

        // Move o inimigo na direção do player
        BadBugRG.AddForce(direcao * velocidade);
    }

    void OnColliderStay(Collider colisao)
    {
        if (colisao.gameObject.tag == "ArvoreMae")
        {
            colisao.GetComponent<VidaGeral>().TomaToma(dano);
        }
        if (colisao.gameObject.tag == "Player")
        {
            colisao.GetComponent<VidaGeral>().TomaToma(dano);
        }
    }
}
