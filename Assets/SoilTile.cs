using UnityEngine;

public class SoilTile : MonoBehaviour
{
    public Transform plantSpot;
    public bool isPlanted = false;
    private GameObject currentPlant;

    public void OnClickTile()
    {
        if (isPlanted) return;

        Debug.Log("Click vào đất: " + gameObject.name);

        if (SeedMenu.Instance != null)
        {
            if (!isPlanted)
            {
                SeedMenu.Instance.OpenMenu(this);
            }
            else
            {
                Debug.Log("Ô đất này đã trồng rồi!");
            }
        }
    }

    public void PlantSeed(GameObject seedPrefab)
    {
        if (isPlanted) return;
        if (plantSpot == null)
        {
            Debug.LogError("PlantSpot chưa được gán trong " + gameObject.name);
            return;
        }
        if (seedPrefab == null)
        {
            Debug.LogError("Prefab hạt giống null!");
            return;
        }
        currentPlant = Instantiate(seedPrefab, plantSpot.position, Quaternion.identity, plantSpot);
        Plant plantScript = currentPlant.GetComponent<Plant>();
        if (plantScript != null)
        {
            plantScript.soilTile = this;
        }

        isPlanted = true;
        Debug.Log("Đã gieo hạt trên đất!");
    }
    
    public void ClearSoil()
    {
        if (currentPlant != null)
        {
            Destroy(currentPlant);
        }

        currentPlant = null;
        isPlanted = false;

        Debug.Log("Đất " + gameObject.name + " đã trống, có thể trồng lại.");
    }

}
