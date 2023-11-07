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
        // Adicione outros campos específicos do carro, se necessário
    }
    
    private List<CarData> cars = new List<CarData>();
    private GameObject player;
    private Transform playerCamera;
    private CinemachineFreeLook freeLook;
    public bool TanoPlayer = true;
    private Vector3 carroPosition;
    public Transform Perso;
    public GameObject demoinho;
    public bool CarroEstaAtivo = false;
    bool Ptrade = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = Camera.main.transform; // Assumindo que você está usando a câmera principal

        // Encontre os objetos com a tag "Car" e adicione cada um deles a CarData
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

        // Não é necessário verificar o objeto do carro aqui
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CarData closestCar = FindClosestCar();
            if (closestCar != null)
            {
                Ptrade = true;
                CarroEstaAtivo = !CarroEstaAtivo;
                if (TanoPlayer == true)
                {   
                    demoinho.SetActive(false);
                    freeLook.Follow = closestCar.carTransform;
                    freeLook.LookAt = closestCar.carTransform;
                    closestCar.carGameObject.GetComponent<CarController>().CarroAtivo(CarroEstaAtivo);
                }
                else
                {
                    demoinho.SetActive(true);
                    freeLook.Follow = Perso;
                    freeLook.LookAt = Perso;
                    carroPosition = closestCar.carTransform.position;
                    demoinho.transform.position = carroPosition;
                    closestCar.carGameObject.GetComponent<CarController>().CarroAtivo(CarroEstaAtivo);
                }
                
                TanoPlayer = !TanoPlayer;
            }
            else
            {
                Ptrade = false;
            }
        }
    }

    public void DentroCarro(bool car)
    {
        Ptrade = car;
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
