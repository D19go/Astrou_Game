using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissoesP1 : MonoBehaviour
{

    public TextMeshProUGUI textoTela;

    bool missao_pegar_moedas = true;
    bool missaoo_dar_pulos = false;
    bool missao_chegar_final = false;

    int Pedras_pegas = 0;
    int Pedras_objetivo = 5;

    int pulos_dados = 0;
    int pulos_objetivo = 3;
    int Boss_dados = 0;
    int Boss_objetivo = 3;
    

    bool plataforma_alcancada = false;

    // Start is called before the first frame update
    void Start()
    {
        ListaMissoes();
    }

    public void ListaMissoes(){
        if( missao_pegar_moedas == true ){
            textoTela.text = "<b>Ache 4 Pedras espalhadas pelo mapa</b>\nPedras "+Pedras_pegas+"/"+Pedras_objetivo;
            if( Pedras_pegas >= Pedras_objetivo ){
                missao_pegar_moedas = false;
                missaoo_dar_pulos = true;
            }
        }
        if( missaoo_dar_pulos == true ){
            textoTela.text = "<b>Proteja a Árvore Mãe!</b>\nPulos "+pulos_dados+"/"+pulos_objetivo;
        }
        if( missao_chegar_final == true ){
            textoTela.text = "<b>Mate todos os Bosses!</b>\nPulos "+Boss_dados+"/";/*Boss_objetivo;*/
        }
    }

    public void pegaMoeda(){
        ListaMissoes();
    }

}