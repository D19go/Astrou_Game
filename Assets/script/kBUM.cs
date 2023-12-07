using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kBUM : MonoBehaviour
{
    [SerializeField] private GameObject bum;
    [SerializeField] private GameObject area;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            StartCoroutine(kbom());
        }
    }

    IEnumerator kbom(){
        bum.SetActive(true);
        area.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        area.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        bum.SetActive(false);
    }

    /*void kbom(){
        bum.SetActive(true);
        area.SetActive(true);
        Invoke("desKBUM", 1.5f);
    }

    void desKBUM(){
        bum.SetActive(false);
        area.SetActive(false);
    }*/
}
