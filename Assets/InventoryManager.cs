using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class InventorySlot
{
    public string itemName;     
    public int count;         
    public Image icon;         
    public TextMeshProUGUI countText; 
}

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots;

    public void AddItem(string itemID, Sprite icon, int amount = 4)
    {
        foreach (var slot in slots)
        {
            if (slot.itemName == itemID)
            {
                slot.count += amount;
                slot.countText.text = slot.count > 0 ? slot.count.ToString() : "";
                return;
            }
        }

        foreach (var slot in slots)
        {
            if (string.IsNullOrEmpty(slot.itemName))
            {
                slot.itemName = itemID;
                slot.count = amount;
                slot.icon.sprite = icon;
                slot.icon.enabled = true;
                slot.countText.text = slot.count > 0 ? slot.count.ToString() : "";
                return;
            }
        }
        Debug.Log("Inventory đầy!");
    }
}
