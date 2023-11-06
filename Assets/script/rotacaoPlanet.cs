using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacaoPlanet : MonoBehaviour
{
   public float g = 0.5f;

    void Update()
    {
        transform.Rotate (0, g * Time.deltaTime, 0);
    }
}
