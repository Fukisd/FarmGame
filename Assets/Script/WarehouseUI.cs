using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarehouseUI : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI carrotText;
    public TextMeshProUGUI cornText;
    public TextMeshProUGUI cauliflowerText;
    public TextMeshProUGUI broccoliText;
    public Button closeButton;

    private void Start()
    {
        panel.SetActive(false);
        closeButton.onClick.AddListener(CloseWarehouse);
    }

    public void OpenWarehouse()
    {
        panel.SetActive(true);
        UpdateUI();
    }

    public void CloseWarehouse()
    {
        panel.SetActive(false);
    }

    private void UpdateUI()
    {
        carrotText.text = Warehouse.Instance.GetItemCount("Carrot").ToString();
        cornText.text = Warehouse.Instance.GetItemCount("Corn").ToString();
        cauliflowerText.text = Warehouse.Instance.GetItemCount("Cauliflower").ToString();
        broccoliText.text = Warehouse.Instance.GetItemCount("Broccoli").ToString();
    }
}
