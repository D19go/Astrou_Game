using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CancelGame : MonoBehaviour
{
    private cAstronautThirdPersonCamera cam3P;
    private Cam1P cam1P;
    private AstronautPlayer player;

    void OnEnable(){
        cam1P = FindAnyObjectByType<Cam1P>();
        cam3P = FindAnyObjectByType<cAstronautThirdPersonCamera>();
        player = FindAnyObjectByType<AstronautPlayer>();
       cam3P.invAtivo(false);
       player.invAtivo(false);
       cam1P.invAtivo(false);
    }
    
    void OnDisable(){
        cam1P = FindAnyObjectByType<Cam1P>();
        cam3P = FindAnyObjectByType<cAstronautThirdPersonCamera>();
        player = FindAnyObjectByType<AstronautPlayer>();
       cam3P.invAtivo(true);
       player.invAtivo(true);
       cam1P.invAtivo(true);
    }
}
