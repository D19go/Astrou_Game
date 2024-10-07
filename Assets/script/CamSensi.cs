using AstronautThirdPersonCamera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSensi : MonoBehaviour
{
    public Cam1P cam1;
    public cAstronautThirdPersonCamera cam3p;
    
    public void TradeSensi(float sensi)
    {
        cam1.Sensi(sensi);
        cam3p.Sensi(sensi);
    }

}
