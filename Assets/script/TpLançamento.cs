using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TPspace : MonoBehaviour
{
   void OnCollisionEnter(Collision colisao){
        if (colisao.gameObject.tag == "Car"){
            SceneManager.LoadScene("LocalPartida");
        }
   }
}
