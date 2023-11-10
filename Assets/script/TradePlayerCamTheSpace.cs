using UnityEngine;
using System.Collections.Generic;
using Cinemachine;

public class TrdaePlayerCamTheSpace : MonoBehaviour
{
    [System.Serializable]
    public class CarData
    {
        public Transform carTransform;
        public GameObject carGameObject;
    }

    private CarData currentCar; // Adicione uma variável para rastrear o carro atual
    private List<CarData> cars = new List<CarData>();
    private GameObject player;
    private CinemachineFreeLook freeLook;
    public Transform Perso;
    public GameObject demoinho;
    public bool CarroEstaAtivo = false;
    bool Ptrade = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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

        Ptrade = false;
        CarroEstaAtivo = false;
        freeLook = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleCar();
        }

        // Verifica se o jogador quer sair do carro a qualquer momento
        if (Input.GetKeyDown(KeyCode.G) && CarroEstaAtivo)
        {
            Ptrade = false;
            CarroEstaAtivo = false;
            demoinho.SetActive(true);
            SwitchCameraToPlayer();
        }
    }

    void ToggleCar()
    {
        if (CarroEstaAtivo)
        {
            Ptrade = false;
            CarroEstaAtivo = false;
            demoinho.SetActive(true);
            SwitchCameraToPlayer();
        }
        else
        {
            CarData closestCar = FindClosestCar();

            if (closestCar != null)
            {
                Ptrade = true;
                CarroEstaAtivo = true;

                // Entrar no carro
                demoinho.SetActive(false);
                SwitchCameraToCar(closestCar);
            }
        }
    }

    void SwitchCameraToCar(CarData carData)
    {
        freeLook.Follow = carData.carTransform;
        freeLook.LookAt = carData.carTransform;
        carData.carGameObject.GetComponent<CarController>().CarroAtivo(CarroEstaAtivo);
        currentCar = carData; // Atualiza o carro atual
        Debug.Log("Entrou no carro");
    }

    void SwitchCameraToPlayer()
    {
        freeLook.Follow = Perso;
        freeLook.LookAt = Perso;
        if (currentCar != null)
        {
            currentCar.carGameObject.GetComponent<CarController>().CarroAtivo(CarroEstaAtivo);
            currentCar = null; // Limpa o carro atual
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
