using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TrdaePlayerCam : MonoBehaviour
{
    private List<GameObject> cars = new List<GameObject>();
    private GameObject player;
    private CinemachineFreeLook freeLook;
    bool TanoPlayer = true;
    public Transform Carro;
    private Vector3 carroPosition;
    public Transform navi;
    private Vector3 naviPosition;
    public Transform Perso;
    public GameObject demoinho;
    public GameObject carro;
    public GameObject Navi;
    public bool AeroEstaAtivo = false;
    public bool CarroEstaAtivo = false;
    bool Ptrade = false;
    public bool saiu = true;

    void Start(){
        GameObject[] carObjects = GameObject.FindGameObjectsWithTag("Car");
        cars.AddRange(carObjects);
        player = GameObject.FindGameObjectWithTag("Player");
        Ptrade = true;
        CarroEstaAtivo = false;
        AeroEstaAtivo = false;
        saiu = false;
        freeLook = GetComponent<CinemachineFreeLook>();
        // navi.GetComponent<voo>().AviaoAtivo(AeroEstaAtivo);
        carro.GetComponent<CarController>().CarroAtivo(CarroEstaAtivo);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            GameObject closeCar = FindClosestCar();
            if(closeCar != null){
                Ptrade = true;
                CarroEstaAtivo = !CarroEstaAtivo;
                if(TanoPlayer == true){
                    freeLook.Follow = Carro;
                    freeLook.LookAt = Carro;      
                    carro.GetComponent<CarController>().CarroAtivo(CarroEstaAtivo);         
                }else{
                
                    demoinho.SetActive(true);
                    freeLook.Follow = Perso;
                    freeLook.LookAt = Perso;
                    carroPosition = Carro.position;
                    demoinho.transform.position = carroPosition;
                    carro.GetComponent<CarController>().CarroAtivo(CarroEstaAtivo);               
                }
                TanoPlayer = !TanoPlayer;
            }else{
                Ptrade = false;
            }
        }

       
        
    }

    public void DentroCarro(bool car){
        Ptrade = car;
    }
    GameObject FindClosestCar()
    {
        GameObject closestCar = null;
        float closestDistance = float.MaxValue;

        foreach (var car in cars)
        {
            float distance = Vector3.Distance(player.transform.position, car.transform.position);

            if (distance <= 30 && distance < closestDistance)
            {
                closestCar = car;
                closestDistance = distance;
            }
        }

        return closestCar;
    }
}
