using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class aviso : MonoBehaviour
{
    HashSet<Collision> toque = new HashSet<Collision>();
    public GameObject text;
    private void Update()
    {
        toque.RemoveWhere(coli => coli == null || !coli.gameObject.activeInHierarchy);
    }
    private void OnCollisionEnter(Collision coli)
    {
        if(coli.gameObject.tag == "Player" || coli.gameObject.tag == "Car"){
            text.SetActive(true);
            toque.Add(coli);
        }
    }

    private void OnCollisionExit(Collision coli)
    {
        if (toque.Contains(coli))
        {
            toque.Remove(coli);
        }
        if (toque.Count == 0)
        {
            text.SetActive(false);

        }
    }
}
