using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpSpace : MonoBehaviour
{
   void OnCollisionEnter(Collision colisao){
        if (colisao.gameObject.tag == "nave"){
            SceneManager.LoadScene("Espaco");
        }
   }
}
