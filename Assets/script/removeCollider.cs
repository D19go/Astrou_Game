using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class removeCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision colisao){
        if (colisao.gameObject.tag == "objeto"){
           Destroy(colisao.gameObject);
        }

        // if (colisao.gameObject.tag == "Player"){
        //    Destroy(colisao.gameObject);
        // }

        // if (colisao.gameObject.tag == "Player"){
        //    Destroy(colisao.gameObject);
        // }

        // if (colisao.gameObject.tag == "Player"){
        //    Destroy(colisao.gameObject);
        // }
        
        
    }
}