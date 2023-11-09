using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spanw : MonoBehaviour
{
    public GameObject inimigo;
    public GameObject inimigo2;
    public GameObject inimigo3;
    public int total = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnNewMob();
    }

    // Update is called once per frame
    void Update()
    {
        if (total >= 4)
        {
            SpawnEnemy(inimigo, 1);
            SpawnEnemy(inimigo2, 2);
            SpawnEnemy(inimigo3, 3);

            total = 0;
            spawnNewMob();
        }
    }

    void SpawnEnemy(GameObject enemyPrefab, int positionIndex)
    {
        // Instancie o inimigo
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Ajuste as coordenadas de deslocamento
        float offsetX = positionIndex; // Altere conforme necessário
        newEnemy.transform.Translate(offsetX, 0, 0);

        // Adicione a força
        newEnemy.GetComponent<Rigidbody>().AddForce(Vector3.up * 2000);
    }

    public void Quantos(int menos1)
    {
        total += menos1;
    }

    void spawnNewMob()
    {
        Vector3 inicio_mapa = new Vector3(20, 11, 21);
        Vector3 fim_mapa = new Vector3(900, 11, 900);

        transform.position = new Vector3(
            Random.Range(inicio_mapa.x, fim_mapa.x),
            11,
            Random.Range(inicio_mapa.z, fim_mapa.z)
        );
    }
}
