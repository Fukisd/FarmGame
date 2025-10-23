using UnityEngine;

public class Plant : MonoBehaviour
{
    [Header("Các stage của cây (theo thứ tự)")]
    public GameObject[] growthStages;
    public float timePerStage = 5f; 

    [Header("Harvest")]
    public GameObject harvestItemPrefab;
    public SoilTile soilTile;   

    private int currentStage = 0;
    private float timer = 0f;
    private GameObject currentModel;
    private bool readyToHarvest = false;

    void Start()
    {
        
        SpawnStage(0);
    }

    void Update()
    {
        if (readyToHarvest) return;

        timer += Time.deltaTime;

        if (timer >= timePerStage && currentStage < growthStages.Length - 1)
        {
            timer = 0f;
            currentStage++;
            if (currentStage < growthStages.Length)
            {
                SpawnStage(currentStage);
                if (currentStage == growthStages.Length - 1)
                {
                    readyToHarvest = true;
                    Debug.Log("🌾 Cây đã sẵn sàng thu hoạch!");
                }
            }
            // SpawnStage(currentStage);
        }
    }

    void SpawnStage(int stageIndex)
    {
        if (currentModel != null) Destroy(currentModel);

        currentModel = Instantiate(
            growthStages[stageIndex],
            transform.position,
            Quaternion.identity,
            transform
        );
        if (currentModel.GetComponent<Collider>() == null)
        {
            currentModel.AddComponent<BoxCollider>();
        }

        Debug.Log("Cây chuyển sang stage: " + stageIndex);
    }

    private void OnMouseDown()
    {
         Debug.Log("👉 Click vào cây!");
         
        if (readyToHarvest)
        {
            Harvest();
        }
        else
        {
            Debug.Log("🌱 Cây chưa chín, chưa thể thu hoạch.");
        }
    }

    // public bool IsReadyToHarvest()
    // {
    //     return currentStage == growthStages.Length - 1;
    // }

    public void Harvest()
    {
        if (harvestItemPrefab != null)
        {
            Instantiate(harvestItemPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        if (soilTile != null)
        {
            soilTile.ClearSoil();
        }

        Debug.Log("Thu hoạch xong!");
        Destroy(gameObject);
    }
}
