using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimateText : MonoBehaviour
{

    public float velocidade = 0.1f;
    bool aumentar = false;
    CanvasGroup canvasGroup;
    float alphaValue;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = transform.GetComponent<CanvasGroup>();
        InvokeRepeating("Animate", 0, Time.fixedDeltaTime);
    }

    void Animate()
    {
        if (aumentar == true)
            canvasGroup.alpha += velocidade;
        else
            canvasGroup.alpha -= velocidade;

        if(canvasGroup.alpha <= 0)
            aumentar = true;
        if (canvasGroup.alpha >= 1)
            aumentar = false;

    }
}
