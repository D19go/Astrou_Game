using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCams : MonoBehaviour
{
    
    public class CarData
    {
        public Transform carTransform;
        public GameObject carGameObject;
    }

    private CarData currentCar; // Adicione uma variável para rastrear o carro atual
    private List<CarData> cars = new List<CarData>();
    private GameObject player;
    private Transform playerTransform;
    public bool CarroEstaAtivo = false;
    [SerializeField] private float offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        GameObject[] carObjects = GameObject.FindGameObjectsWithTag("Car");
        foreach (var carObject in carObjects)
        {
            CarData carData = new CarData
            {
                carTransform = carObject.transform,
                carGameObject = carObject
            };
            cars.Add(carData);
        }

        CarroEstaAtivo = false;
        
    }

    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleCar();
        }

        // Verifica se o jogador quer sair do carro a qualquer momento
        // if (Input.GetKeyDown(KeyCode.G) && CarroEstaAtivo)
        // {
        //     CarroEstaAtivo = false;
        //     player.SetActive(true);
        //     SwitchCameraToPlayer();
        // }
    }

    void ToggleCar()
    {
        if (CarroEstaAtivo)
        {
            CarroEstaAtivo = false;
            SwitchCameraToPlayer();
        }
        else
        {
            CarData closestCar = FindClosestCar();

            if (closestCar != null)
            {
                CarroEstaAtivo = true;
                
                // Entrar no carro
                player.SetActive(false);
                SwitchCameraToCar(closestCar);
            }
        }
    }

    void SwitchCameraToCar(CarData carData)
    {
        carData.carGameObject.GetComponentInParent<CarController>().CarroAtivo(CarroEstaAtivo);
        carData.carGameObject.transform.Find("Cam3P").gameObject.SetActive(true);
        currentCar = carData; // Atualiza o carro atual
        Debug.Log("Entrou no carro");
    }

    void SwitchCameraToPlayer()
    {
        if (currentCar != null){
            currentCar.carGameObject.GetComponent<CarController>().CarroAtivo(CarroEstaAtivo);
            currentCar.carGameObject.transform.Find("Cam3P").gameObject.SetActive(false);
            Vector3 PosiCar = currentCar.carGameObject.transform.position;
            // offset é para colocar o jogador para o lado esquerdo do carro
            Vector3 PosiPlayer = PosiCar - currentCar.carGameObject.transform.right * offset;
            playerTransform.position = PosiPlayer;
            currentCar = null;
            player.SetActive(true);
        }

        Debug.Log("Saiu do carro");
    }

    CarData FindClosestCar()
    {
        CarData closestCar = null;
        float closestDistance = float.MaxValue;

        foreach (var carData in cars)
        {
            float distance = Vector3.Distance(player.transform.position, carData.carTransform.position);

            if (distance <= 10 && distance < closestDistance)
            {
                closestCar = carData;
                closestDistance = distance;
            }
        }

        return closestCar;
    }

}
