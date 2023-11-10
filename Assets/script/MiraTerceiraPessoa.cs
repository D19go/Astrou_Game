using UnityEngine;
using UnityEngine.UI;

public class MiraTerceiraPessoa : MonoBehaviour
{
    public Image miraImage; // Referência para a imagem da mira.
    public Camera cameraTerceiraPessoa; // Referência para a câmera de terceira pessoa.

    void Update()
    {
        // Obter a posição do mouse na tela ou o centro da tela.
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = cameraTerceiraPessoa.transform.position.y - miraImage.transform.position.y;

        // Converter a posição da tela para a posição no mundo.
        Vector3 worldPos = cameraTerceiraPessoa.ScreenToWorldPoint(screenPos);

        // Ajustar a posição da mira.
            miraImage.transform.position = worldPos;
    }
}
