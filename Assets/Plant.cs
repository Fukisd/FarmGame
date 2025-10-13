using UnityEngine;

public class Plant : MonoBehaviour
{
    [Header("Các stage của cây (theo thứ tự)")]
    public GameObject[] growthStages;
    public float timePerStage = 5f; 

    [Header("Harvest")]
    public SoilTile soilTile;   

    [Header("Inventory Info")]
    public string itemName; 
    public Sprite itemIcon;

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
                    Debug.Log("Cây đã sẵn sàng thu hoạch!");
                }
            }
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

        Debug.Log("Cây chuyển sang stage: " + stageIndex);
    }

    private void OnMouseDown()
    {
        if (readyToHarvest)
        {
            Harvest();
        }
        else
        {
            Debug.Log("Cây chưa chín, chưa thể thu hoạch.");
        }
    }

    public void Harvest()
    {
        InventoryManager inventory = FindFirstObjectByType<InventoryManager>();
        if (inventory != null)
        {
            inventory.AddItem(itemName, itemIcon, 4);
        }

        if (soilTile != null)
        {
            soilTile.ClearSoil();
        }

        Debug.Log("Thu hoạch xong + thêm vào inventory!");
        Destroy(gameObject);
    }
}
