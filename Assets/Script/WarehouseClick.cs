using UnityEngine;

public class WarehouseClick : MonoBehaviour
{
    public WarehouseUI warehouseUI;
    private bool isOpen = false;

    private void OnMouseDown()
    {
        Debug.Log("Clicked Warehouse!");

        if (!isOpen)
        {
            warehouseUI.OpenWarehouse();
            isOpen = true;
        }
        else
        {
            warehouseUI.CloseWarehouse();
            isOpen = false;
        }
    }
}
