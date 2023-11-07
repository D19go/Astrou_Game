using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spanw : MonoBehaviour
{
    public GameObject inimigo;
    int total = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnNewMob();
    }

    // Update is called once per frame
    void Update()
    {
        if(total >= 2){
            GameObject nova_inimigo =  Instantiate(inimigo, transform.position, Quaternion.identity);
            nova_inimigo.transform.Translate(0,0,0);
            nova_inimigo.GetComponent<Rigidbody>().AddForce(Vector3.up*2000);
            total = -5;
            spawnNewMob();
        }
    }

    public void Quantos(int menos1){
        total += menos1;
    }

    void spawnNewMob(){
        Vector3 inicio_mapa = new Vector3(20, 11, 21);    
        Vector3 fim_mapa = new Vector3(900, 11, 900);

        transform.position = new Vector3( 
            Random.Range(inicio_mapa.x, fim_mapa.x),
            11,
            Random.Range(inicio_mapa.z, fim_mapa.z)
        );
    }
}
