using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpPlanet : MonoBehaviour
{
     void OnCollisionEnter(Collision colisao){
        if (colisao.gameObject.tag == "nave"){
            SceneManager.LoadScene("Planet_1");
        }
   }
}
