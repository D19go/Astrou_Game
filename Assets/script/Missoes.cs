using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Missoes : MonoBehaviour
{
    public TextMeshProUGUI textoTela;

    private InventarioCTRL inv;
    bool pegar_Chave = true;
    bool fuja_dos_aliens = false;
    // bool missao_chegar_final = false;

    int chave_pegas = 0;
    int chave_objetivo = 1;

    int galoes_pegos;
    int galoes_dados = 0;

    // Start is called before the first frame update
    void Start()
    {
        inv = FindAnyObjectByType<InventarioCTRL>();
        checarMissoes();
    }

    public IEnumerator checarMissoes(){
        yield return new WaitForSeconds(5f);
        for(int i = 0; i < 8; i++ ){
            if( pegar_Chave == true ){
                string nomeObj = "Chave Mestra";
                textoTela.text = "<b>Procure uma chave!\n Está na frente de uma casa azul com dois carros na garagem</b>";
                if( chave_pegas == chave_objetivo ){
                    pegar_Chave = false;
                    fuja_dos_aliens = true;
                }
                if(inv.slots[i].ItemName == nomeObj){
                    chave_pegas++;
                }
            }
            if( fuja_dos_aliens == true ){
                string nomeObj = "Galão de Combustivel";
                textoTela.text = "<b>Ache alguns galões de gasolina para o seu carro!</b>\nGalões "+galoes_dados;

                if(inv.slots[i].ItemName == nomeObj){
                    galoes_pegos++;
                }
            }

        }
        checarMissoes();
    }

   
}