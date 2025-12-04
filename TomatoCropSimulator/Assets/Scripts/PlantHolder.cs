using System.IO;
using NUnit.Framework;
using UnityEngine;

public class PlantHolder : MonoBehaviour
{
    [Header("Image assigned automatically")]
    public string imagePathAssigned;

    [Header("Classification info")]
    public bool hasBeenClassified = false;
    public bool isInfected = false;
    public string predictedClassName;
    private bool hasFruit = false;
    public float minFruitTime = 20f; 
    public float maxFruitTime = 60f;
    private float fruitTimer = 0f;
    private float nextFruitTime = 0f;
    private bool growthCicleActive = true;

    private float infectionChance = .1f; // 10 percent to get infected every time a new plant were ot grow
    
    [Header("Visuals")]
    public GameObject plantModel;
    public GameObject fruitPlantModel;
    public GameObject infectedPlantModel;

    public Color gizmoColorHealthy = Color.green;
    public Color gizmoColorInfected = Color.red;

    void Start()
    {
        hasFruit = false;
        growthCicleActive = true;
        SetNewFruitTime();
        
        plantModel.SetActive(true);
        plantModel.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        fruitPlantModel.SetActive(false);
        fruitPlantModel.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        infectedPlantModel.SetActive(false);
        infectedPlantModel.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    
    void Update()
    {
        if (!hasFruit && growthCicleActive)
        {
            fruitTimer += Time.deltaTime;
            if (fruitTimer >= nextFruitTime)
                GrowFruit();
        }
    }
    
    void GrowFruit()
    {
        hasFruit = true;
        fruitTimer = 0f;
        plantModel.SetActive(false);

        if (isInfected)
        {
            infectedPlantModel.SetActive(true);
        }
        else
        {
            fruitPlantModel.SetActive(true);
        }

    }

    public int HarvestFruit()
    {
        if (!hasFruit) return 0;
        hasFruit = false;

        plantModel.SetActive(true);
        fruitPlantModel.SetActive(false);
        infectedPlantModel.SetActive(false);

        SetNewFruitTime();
        isInfected = Random.value < infectionChance;

        if(isInfected) return 2;
        return 1;
    }
    
    private void SetNewFruitTime()
    {
        nextFruitTime = Random.Range(minFruitTime, maxFruitTime);
    }

    public void CutPlant()
    {
        plantModel.SetActive(false);
        fruitPlantModel.SetActive(false);
        infectedPlantModel.SetActive(false);
        hasFruit = false;
        growthCicleActive = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = hasBeenClassified && isInfected ? gizmoColorInfected : gizmoColorHealthy;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * 0.5f, 0.2f);
    }
}