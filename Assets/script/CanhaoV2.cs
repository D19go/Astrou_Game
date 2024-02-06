using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoV2 : MonoBehaviour
{   

    [SerializeField] private int distancia = 150;
    [SerializeField] private Camera cam1;
    public float timeBetweenShotsMouse0 = 0.5f;
    private float timeSinceLastShotMouse0;
    [SerializeField] private int dano = 75;
    [SerializeField] private GameObject Particulas;
    void Start()
    {
        timeSinceLastShotMouse0 = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShotMouse0 += Time.deltaTime;
        cam1 = Camera.main;
        RaycastHit hit;
        Ray ray = cam1.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
        if(Physics.Raycast(ray, out hit, distancia)){
            if(Input.GetMouseButton(0) && timeSinceLastShotMouse0 >= timeBetweenShotsMouse0){
                Particulas.SetActive(true);
                timeSinceLastShotMouse0 = 0f;  // Resetar o contador de tempo
                if (hit.collider.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
                }
            }else{
            Particulas.SetActive(false);
            }
            if(Input.GetMouseButton(0) && timeSinceLastShotMouse0 >= timeBetweenShotsMouse0){
                Particulas.SetActive(true);
                timeSinceLastShotMouse0 = 0f; 
                if (hit.collider.tag == "Enemy2")
                {
                    hit.collider.gameObject.GetComponent<VidaGeral>().TomaToma(dano);
                     // Resetar o contador de tempo
                }
            }
        }
        
    }
}
