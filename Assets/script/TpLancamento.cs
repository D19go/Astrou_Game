using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpLancamento : MonoBehaviour
{
   void OnCollisionEnter(Collision colisao){
        if (colisao.gameObject.tag == "Car"){
            SceneManager.LoadScene("LocalPartida");
        }
   }
}
