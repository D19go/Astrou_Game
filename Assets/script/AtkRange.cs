using System.Collections;
using UnityEngine;

public class AtkRange : MonoBehaviour
{
    [SerializeField] private GameObject dardo;      
    [SerializeField] private int Forca;             
    [SerializeField] private Animator anim;         
    [SerializeField] private GameObject saida;     
    [SerializeField] private float SpeedATK;        
    private GameObject alvo;                        
    private Vector3 PlayerAlvo;  
    bool pronto = true;                  

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player") && pronto)
        {
            pronto =! pronto;
            alvo = other.gameObject;
            StartCoroutine(animacaoATK());
        }
    }


    public void atk()
    {
        
        if (alvo != null)
        {
            
            GameObject dardo_ = Instantiate(dardo, saida.transform.position, Quaternion.identity);
            PlayerAlvo = (alvo.transform.position - transform.position).normalized;
            Quaternion rotacao = Quaternion.LookRotation(PlayerAlvo);
            dardo_.transform.rotation = rotacao * Quaternion.Euler(90, 0, 0);
            dardo_.GetComponent<Rigidbody>().AddForce(PlayerAlvo * Forca);
        }
    }

    IEnumerator animacaoATK()
    {
        yield return new WaitForSeconds(SpeedATK);
        anim.SetTrigger("SPEELLL");
        // 'pronto' está falso, agora vai se tornar verdadeiro
        pronto =! pronto;
    }
}
