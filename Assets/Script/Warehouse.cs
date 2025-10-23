using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    public static Warehouse Instance;
    private Dictionary<string, int> items = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        items["Carrot"] = 10;
        items["Corn"] = 10;
        items["Cauliflower"] = 10;
        items["Broccoli"] = 10;
    }

    public int GetItemCount(string itemName)
    {
        return items.ContainsKey(itemName) ? items[itemName] : 0;
    }

    public bool RemoveItem(string itemName, int amount)
    {
        if (items.ContainsKey(itemName) && items[itemName] >= amount)
        {
            items[itemName] -= amount;
            return true;
        }
        return false;
    }

    public void AddItem(string itemName, int amount)
    {
        if (!items.ContainsKey(itemName))
            items[itemName] = 0;

        items[itemName] += amount;
    }
}
