using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Missoes : MonoBehaviour
{

    public TextMeshProUGUI textoTela;

    bool missao_pegar_moedas = true;
    bool missaoo_dar_pulos = false;
    // bool missao_chegar_final = false;

    // int moedas_pegas = 0;
    // int moedas_objetivo = 5;

    int pulos_dados = 0;
    int pulos_objetivo = 3;


    // Start is called before the first frame update
    void Start()
    {
        checarMissoes();
    }

    public void checarMissoes(){
        if( missao_pegar_moedas == true ){
            textoTela.text = "<b>Escolha um carro e ache o tunel!\n Caso o carro capote você pode desvirar o carro apertando R, mas isso ira custar uma vida</b>";
            // if( moedas_pegas >= moedas_objetivo ){
            //     missao_pegar_moedas = false;
            //     missaoo_dar_pulos = true;
            // }
        }
        if( missaoo_dar_pulos == true ){
            textoTela.text = "<b>Dê três pulinhos!</b>\nPulos "+pulos_dados+"/"+pulos_objetivo;
        }
        // if( missao_chegar_final == true ){

        // }
    }

    // public void pegaMoeda(){
    //     moedas_pegas += 1;
    //     checarMissoes();
    // }

}