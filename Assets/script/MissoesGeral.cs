using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissoesGeral : MonoBehaviour
{
    public static MissoesGeral instance;

    public TextMeshProUGUI missaoVeiculo;
    public TextMeshProUGUI missaoEstacao;
    public TextMeshProUGUI missaoDecolar;
    public TextMeshProUGUI missaoAterrissar;
    public TextMeshProUGUI missaoPedras;
    public TextMeshProUGUI missaoArvore;
    public TextMeshProUGUI missaoSobreviver;

    public GameObject efeitoArvore;
    public GameObject vidaArvore;
    public GameObject vidaJogador;
    public bool arvoreCompleta = false;

    public static int pedrasRestantes = 4;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AtualizarMissaoPedras();
    }

    public void AtualizarMissaoPedras()
    {
        missaoPedras.text = "• Encontre e colete " + pedrasRestantes + " pedras da vida";
        if(pedrasRestantes <= 0)
        {
            missaoPedras.text = "• Encontre e colete as pedras da vida";
            efeitoArvore.gameObject.SetActive(true);
            vidaArvore.gameObject.SetActive(true);
            AlternarMissoes(missaoPedras, missaoArvore);
        }
    }

    public void CompletarMissao(TextMeshProUGUI missao)
    {
        Color color = Color.white;
        color.a = 0.1f;
        missao.color = color;
        missao.text = "<s>" + missao.text + "</s>";
    }
    public void NovaMissao(TextMeshProUGUI missao)
    {
        Color color = Color.white;
        color.a = 1f;
        missao.color = color;
        missao.text = "<b>" + missao.text + "</b>";
    }
    public void AlternarMissoes( TextMeshProUGUI missaoCompleta, TextMeshProUGUI novaMissao)
    {
        CompletarMissao(missaoCompleta);
        NovaMissao(novaMissao);

        if( arvoreCompleta == true)
        {
            vidaArvore.SetActive(false);
            vidaJogador.SetActive(true);
        }

    }

}
