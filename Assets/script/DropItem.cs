using System.Collections;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    [SerializeField] private GameObject pedra; // num1
    [SerializeField] private GameObject pedra2;// num2
    [SerializeField] private GameObject pedra3;// num3
    [SerializeField] private GameObject pedra4;// num4
    [SerializeField] private GameObject pedra5;// num5
    [SerializeField] private GameObject pedra6;// num6
    [SerializeField] private GameObject fruta;// num7
    int num1 = 1;
    int num2 = 4;
    int num3 = 7;
    int num4 = 10;
    int num5 = 13;
    int num6 = 16;
    int num7= 19;

    
    public IEnumerator dropRate(){
        yield return new WaitForSeconds(1f);
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        int obj = Random.Range(1, 21 +1 ); // Gera um número inteiro aleatório no intervalo [min, max]
        if(obj == num1){
            GameObject pedra_ = Instantiate(pedra, transform.position, Quaternion.identity);
        }else if(obj == num2){
            GameObject pedra_ = Instantiate(pedra2, transform.position, Quaternion.identity);
        }else if(obj == num3){
            GameObject pedra_ = Instantiate(pedra3, transform.position, Quaternion.identity);
        }else if(obj == num4){
            GameObject pedra_ = Instantiate(pedra4, transform.position, Quaternion.identity);
        }else if(obj == num5){
            GameObject pedra_ = Instantiate(pedra5, transform.position, Quaternion.identity);
        }else if(obj == num6){
            GameObject pedra_ = Instantiate(pedra6, transform.position, Quaternion.identity);
        }else if(obj == num7){
            GameObject fruit = Instantiate(fruta, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
