using UnityEngine;

public class SeedMenu : MonoBehaviour
{
    public static SeedMenu Instance;  
    private SoilTile currentTile;

    [Header("Prefab hạt/cây")]
    public GameObject[] seedPrefabs;

    [Header("UI Menu")]
    public GameObject menuUI; 

    private void Awake()
    {
        Instance = this;
        menuUI.SetActive(false);
    }

    public void OpenMenu(SoilTile tile)
    {
        currentTile = tile;
        Debug.Log("Mở menu chọn hạt");   
        
        Vector3 screenPos = Camera.main.WorldToScreenPoint(tile.transform.position);
        menuUI.transform.position = screenPos ;
        menuUI.SetActive(true);
    }

    public void CloseMenu()
    {
        currentTile = null;
        menuUI.SetActive(false);
    }
    public void SelectSeed(int seedIndex)
    {
        if (currentTile == null)
        {
            Debug.LogError("Không có ô đất nào đang chọn!");
            return;
        }
        if (currentTile != null)
        {
            currentTile.PlantSeed(seedPrefabs[seedIndex]);
            CloseMenu();
        }
    }
}
