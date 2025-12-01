using UnityEngine;

public class PlantSpace : MonoBehaviour
{
    public GameObject plantModel;
    public GameObject fruitPlantModel;

    private bool hasFruit = false;
    public bool infected = false;

    public float minFruitTime = 20f; 
    public float maxFruitTime = 60f;
    private float fruitTimer = 0f;
    private float nextFruitTime = 0f;
    private bool growthCicleActive = true;

    void Start()
    {
        hasFruit = false;
        growthCicleActive = true;
        SetNewFruitTime();
        
        plantModel.SetActive(true);
        fruitPlantModel.SetActive(false);

        infected = Random.value < 0.1f; // 10% 
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
        fruitPlantModel.SetActive(true);
    }

    public int HarvestFruit()
    {
        if (!hasFruit) return 0;
        hasFruit = false;

        plantModel.SetActive(true);
        fruitPlantModel.SetActive(false);

        SetNewFruitTime();

        if(infected) return 2;
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
        growthCicleActive = false;
    }
}
