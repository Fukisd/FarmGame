using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BarnUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject panel;
    public Image carrotImage;
    public Image cornImage;
    public Image cauliflowerImage;
    public Image broccoliImage;
    public Button closeButton;

    private string barnName = "Chuồng không tên";

    private void Start()
    {
        panel.SetActive(false);

        // Gán sự kiện click cho hình ảnh
        AddClickListener(carrotImage, () => FeedAnimal("Carrot"));
        AddClickListener(cornImage, () => FeedAnimal("Corn"));
        AddClickListener(cauliflowerImage, () => FeedAnimal("Cauliflower"));
        AddClickListener(broccoliImage, () => FeedAnimal("Broccoli"));

        // Gán sự kiện đóng panel
        closeButton.onClick.AddListener(ClosePanel);
    }

    private void AddClickListener(Image img, UnityEngine.Events.UnityAction action)
    {
        // Đảm bảo hình có component Button hoặc EventTrigger để bắt click
        Button btn = img.GetComponent<Button>();
        if (btn == null)
        {
            btn = img.gameObject.AddComponent<Button>();
            btn.transition = Selectable.Transition.None;
        }
        btn.onClick.AddListener(action);
    }

    public void OpenPanel(string name)
    {
        barnName = name;
        panel.SetActive(true);
        Debug.Log($"Mở chuồng {barnName} thành công!");
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    private void FeedAnimal(string foodType)
    {
        if (Warehouse.Instance.RemoveItem(foodType, 1))
        {
            Debug.Log($"{barnName}: Đã cho ăn {foodType}. Còn lại {Warehouse.Instance.GetItemCount(foodType)} trong kho.");
        }
        else
        {
            Debug.Log($"{barnName}: Không đủ {foodType} trong kho!");
        }
        ClosePanel();
    }
}
