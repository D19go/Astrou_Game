using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;    
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{

    [SerializeField] int vida;
    int vidaBase;
    [SerializeField] Image vidaBar;
    [SerializeField] Image escBar;
    bool esc = false;
    bool escVidaBaixa = false;
    public int vida_Esc;
    int sobraDano;
    int max_Vida_Escudo;
    float tempo;

    private Coroutine regenRoutine = null;

    // Start is called before the first frame update
    public void Start()
    {
       
        vidaBase = vida;
        tempo = 0.5f;
        max_Vida_Escudo = vida_Esc;
    }

    public void Escudo_Ativo(bool ativo)
    {
        esc = ativo;
        // Inicia regeneração quando o escudo é desativado
        if (!esc && vida_Esc < max_Vida_Escudo && regenRoutine == null)
        {
            regenRoutine = StartCoroutine(RegenerarEscudo());
        }
        // Para regeneração se o escudo for ativado
        else if (esc && regenRoutine != null)
        {
            StopCoroutine(regenRoutine);
            regenRoutine = null;
        }
    }

    // Update is called once per frame
    void Hits_Esc(int dano)
    {
        if (dano > vida_Esc)
        {
            sobraDano = dano - vida_Esc;
            vida_Esc = 0;
            esc = false; // Desativa o escudo
        }
        else
        {
            vida_Esc -= dano;
            sobraDano = 0; // Se o escudo absorver todo o dano, sobraDano será 0
        }

        float fillAmount = (float)vida_Esc / max_Vida_Escudo;
        escBar.fillAmount = fillAmount;

        if (sobraDano > 0)
        {
            // Se ainda sobrar dano após o escudo ser destruído, aplicar o dano restante na vida
            Vida_Manager(sobraDano);
        }

        if (vida_Esc <= 0)
        {
            vida_Esc = 0;
            esc = false;
        }
    }

    public void Vida_Manager(int dano)
    {
        if (esc)
        {
            // Se o escudo estiver ativo, apenas aplica dano ao escudo
            Hits_Esc(dano);
        }
        else
        {
            // Se o escudo não estiver ativo, aplica o dano diretamente à vida
            vida -= dano;
            float fillAmount = (float)vida / vidaBase;
            vidaBar.fillAmount = fillAmount;
            if (vida <= 0)
            {
                Debug.Log("morreu");
                IEnumerator revive()
                {
                    yield return new WaitForSeconds(1);
                    /*vida = vidaBase;
                    float fillAmount = (float)vida / vidaBase;
                    vidaBar.fillAmount = fillAmount;*/
                }
            }
        }

    }

    private IEnumerator RegenerarEscudo()
    {
        escVidaBaixa = true;

        // Continua regenerando enquanto o escudo estiver desativado e a vida não estiver cheia
        while (escVidaBaixa && vida_Esc < max_Vida_Escudo)
        {
            yield return new WaitForSeconds(tempo);
            vida_Esc += (max_Vida_Escudo * 2) / 100;
            vida_Esc = Mathf.Min(vida_Esc, max_Vida_Escudo); // Impede ultrapassar o máximo
            float fillAmount = (float)vida_Esc / max_Vida_Escudo;
            escBar.fillAmount = fillAmount;
        }

        regenRoutine = null; // Regeneração concluída, libera a corrotina
        if (vida_Esc > max_Vida_Escudo)
        {
            vida_Esc = max_Vida_Escudo;
        }
    }
}
