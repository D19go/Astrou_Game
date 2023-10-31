using UnityEngine;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour
{
    private List<GameObject> cars = new List<GameObject>();
    private GameObject player;
    private GameObject currentCar;

    public float interactionDistance = 3.0f; // Distância máxima para a interação

    private Transform playerCamera; // A câmera do jogador

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = Camera.main.transform; // Assumindo que você está usando a câmera principal

        GameObject[] carObjects = GameObject.FindGameObjectsWithTag("Car");
        cars.AddRange(carObjects);

        // Desative o CarController do carro atual (não há um atualmente)
        if (currentCar != null)
        {
            currentCar.GetComponent<CarController>().enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentCar == null)
            {
                GameObject closestCar = FindClosestCar();
                if (closestCar != null)
                {
                    currentCar = closestCar;
                    ActivateCarController(currentCar);
                }
            }
            else
            {
                DeactivateCarController(currentCar);
                currentCar = null;
            }
        }
    }

    GameObject FindClosestCar()
    {
        GameObject closestCar = null;
        float closestDistance = float.MaxValue;

        foreach (var car in cars)
        {
            float distance = Vector3.Distance(player.transform.position, car.transform.position);

            if (distance <= interactionDistance && distance < closestDistance)
            {
                closestCar = car;
                closestDistance = distance;
            }
        }

        return closestCar;
    }

    void ActivateCarController(GameObject car)
    {
        car.GetComponent<CarController>().enabled = true;

        // Mude o foco da câmera para o carro mais próximo
        playerCamera.position = car.transform.position;
        playerCamera.LookAt(car.transform);
    }

    void DeactivateCarController(GameObject car)
    {
        car.GetComponent<CarController>().enabled = false;

        // Restaure a câmera para o jogador ou qualquer outro comportamento de câmera necessário
        playerCamera.position = player.transform.position;
        playerCamera.LookAt(player.transform);
    }
}
