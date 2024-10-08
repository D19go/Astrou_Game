using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissoesP1 : MonoBehaviour
{

    public TextMeshProUGUI textoTela;

    public GameObject spanwEnemy;
    public GameObject Enemy;    
    public bool Mincompleta = true; 
    private InventarioCTRL slots;

    public GameObject Arma;
    bool missao_pegar_moedas = true;
    bool missaoo_dar_pulos = false;

    int Pedras_pegas = 0;
    int Pedras_objetivo = 4;

    int Waves_Total = 0;
    int Waves_objetivo = 6;

    // int Boss_dados = 0;
    // int Boss_objetivo = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        slots = FindAnyObjectByType<InventarioCTRL>(); 
        Enemy.SetActive(false);
        
    }

    public void ListaMissoes(){
        for(int i = 0; i < 8; i++){
            if( missao_pegar_moedas){
                textoTela.text = "<b>Ache 4 Pedras espalhadas próximas a grande árvore \n Ache as pedras para poder ligar o canhão acima de você</b>\nPedras "+Pedras_pegas+"/"+Pedras_objetivo;
                if( Pedras_pegas >= Pedras_objetivo ){
                    missaoo_dar_pulos = true;
                    spanwEnemy.GetComponent<spanw>().Comeca(missaoo_dar_pulos);
                    bool ok = true;
                    Arma.GetComponent<nhao>().M1Concluida(ok);
                    Enemy.SetActive(true);
                    missao_pegar_moedas = false;
                }
            }
            if( missaoo_dar_pulos == true ){
                textoTela.text = "<b>Proteja a Árvore</b>\nWaves "+Waves_Total+"/"+Waves_objetivo;
                if(Waves_Total > Waves_objetivo){
                    spanwEnemy.SetActive(false);
                    textoTela.text = "<b>PARABÉNS VOCÊ CONSEGUIU</b>\nMate a ultima wave";
                }

            }

        }
    }   

    public void Pedras()
    {
        Pedras_pegas++;
        MissoesGeral.pedrasRestantes--;
        ListaMissoes();
    }

    public void Wave(){
        Waves_Total += 1;
        ListaMissoes();
    }

}