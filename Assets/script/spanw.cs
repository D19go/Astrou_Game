using System.Collections;
using UnityEngine;

public class spanw : MonoBehaviour
{
    public GameObject inimigo;
    public GameObject inimigo2;
    public GameObject inimigo3;

    public bool PodeWave = false;
    public int total = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnNewMob();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PodeWave)
        {
            return;
        }

        if (total >= 18)  // Alterado para gerar 9 inimigos no total
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnEnemy(inimigo, i);
                SpawnEnemy(inimigo2, i);
                SpawnEnemy(inimigo3, i);
            }

            total = 0;
            spawnNewMob();
        }
    }

    void SpawnEnemy(GameObject enemyPrefab, int positionIndex)
    {
        // Instancie o inimigo
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Ajuste as coordenadas de deslocamento
        float offsetX = Random.Range(20f, 900f); // Altere conforme necessário
        float offsetZ = Random.Range(20f, 900f); // Altere conforme necessário

        newEnemy.transform.position = new Vector3(offsetX, 11, offsetZ);

        // Adicione a força
        newEnemy.GetComponent<Rigidbody>().AddForce(Vector3.up * 2000);
    }

    public void Comeca(bool missaoDarPulos)
    {
        PodeWave = missaoDarPulos;
    }

    public void Quantos(int menos1)
    {
        total += menos1;
    }

    void spawnNewMob()
    {
        // Não é mais necessário ajustar a posição do transform
    }
}
