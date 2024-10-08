using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manual: MonoBehaviour
{
    public Button botaoJogar;
    public Button botaoSair;
    public Button botaoManual;


    private void Update()
    {
        if (Input.GetAxis("Fire2") != 0)
            SceneManager.LoadScene("Começo");
    }

}
