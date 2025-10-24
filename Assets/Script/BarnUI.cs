using UnityEngine;
using UnityEngine.UI;

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
        if(panel == null)
        {
            Debug.LogError("Panel chưa được gán trong Inspector!");
            return;
        }

        panel.SetActive(false);

        AddClickListenerSafe(carrotImage, "Carrot");
        AddClickListenerSafe(cornImage, "Corn");
        AddClickListenerSafe(cauliflowerImage, "Cauliflower");
        AddClickListenerSafe(broccoliImage, "Broccoli");

        if(closeButton != null)
            closeButton.onClick.AddListener(ClosePanel);
        else
            Debug.LogError("CloseButton chưa được gán trong Inspector!");
    }

    private void AddClickListenerSafe(Image img, string food)
    {
        if(img == null)
        {
            Debug.LogError($"{food} Image chưa được gán trong Inspector!");
            return;
        }

        Button btn = img.GetComponent<Button>();
        if(btn == null)
        {
            btn = img.gameObject.AddComponent<Button>();
            btn.transition = Selectable.Transition.None;
        }

        btn.onClick.AddListener(() => FeedAnimal(food));
    }

    public void OpenPanel(string name)
    {
        barnName = name;
        if(panel != null)
        {
            panel.SetActive(true);
            Debug.Log($"Mở chuồng {barnName} thành công!");
        }
    }

    public void ClosePanel()
    {
        if(panel != null)
            panel.SetActive(false);
    }

    private void FeedAnimal(string foodType)
    {
        if(Warehouse.Instance == null)
        {
            Debug.LogError("Warehouse.Instance chưa được khởi tạo!");
            return;
        }

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
