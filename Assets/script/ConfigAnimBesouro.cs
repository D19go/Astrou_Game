using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigAnim : MonoBehaviour
{
    [SerializeField] private Animator animacao;
    
    bool ataqueSim = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void perto(){
        ataqueSim = !ataqueSim;
        gameObject.GetComponentInChildren<DanoEnemy>().enabled = ataqueSim;
    }
}
