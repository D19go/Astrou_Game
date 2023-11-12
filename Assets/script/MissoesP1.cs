using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissoesP1 : MonoBehaviour
{

    public TextMeshProUGUI textoTela;

    public GameObject spanwEnemy;
    public GameObject Enemy;

    public GameObject Arma;
    bool missao_pegar_moedas = true;
    bool missaoo_dar_pulos = false;

    int Pedras_pegas = 0;
    int Pedras_objetivo = 4;

    int Waves_Total = 0;
    int Waves_objetivo = 2;

    // int Boss_dados = 0;
    // int Boss_objetivo = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        Enemy.SetActive(false);
        ListaMissoes();
    }

    public void ListaMissoes(){
        if( missao_pegar_moedas == true ){
            textoTela.text = "<b>Ache 4 Pedras espalhadas próximas a grande árvore</b>\nPedras "+Pedras_pegas+"/"+Pedras_objetivo;
            if( Pedras_pegas >= Pedras_objetivo ){
                missaoo_dar_pulos = true;
                spanwEnemy.GetComponent<spanw>().Comeca(missaoo_dar_pulos);
                bool ok = true;
                Arma.GetComponent<nhao>().M1Concluida(ok);
                Enemy.SetActive(true);
            }
        }
        if( missaoo_dar_pulos == true ){
            textoTela.text = "<b>Proteja a Árvore</b>\nWaves "+Waves_Total+"/"+Waves_objetivo;
            if(Waves_Total >= Waves_objetivo){
                Enemy.SetActive(false);
                spanwEnemy.SetActive(false);
                textoTela.text = "<b>PARABÉNS VOCÊ CONSEGUIU</b>";
            }
        }
    }

    public void pegaPedras(){
        Pedras_pegas += 1;
        ListaMissoes();
    }

    public void Wave(){
        Waves_Total += 1;
        ListaMissoes();
    }

}