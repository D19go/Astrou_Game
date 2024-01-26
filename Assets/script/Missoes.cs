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

    int chave_pegas = 0;
    int chave_objetivo = 1;

    int galoes_dados = 0;

    // Start is called before the first frame update
    void Start()
    {
        checarMissoes();
    }

    public void checarMissoes(){
        if( missao_pegar_moedas == true ){
            textoTela.text = "<b>Procure uma chave!\n Está na frente de uma casa azul com dois carros na garagem</b>";
            if( chave_pegas >= chave_objetivo ){
                missao_pegar_moedas = false;
                missaoo_dar_pulos = true;
            }
            
        }
        if( missaoo_dar_pulos == true ){
            textoTela.text = "<b>Ache alguns galões de gasolina para o seu carro!</b>\nGalões "+galoes_dados;
        }
        // if( missao_chegar_final == true ){

        // }
    }

    public void pegaChave(){
        chave_pegas += 1;
        checarMissoes();
    }

    public void pegaGalao(){
        galoes_dados += 1;
        checarMissoes();
    }

}