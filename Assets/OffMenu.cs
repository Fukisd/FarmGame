using UnityEngine;

public class OffMenu : MonoBehaviour
{
    [SerializeField] private GameObject seedMenu; 

    public void ClosePanel()
    {
        seedMenu.SetActive(false);
    }
//uhhhhhhhh
}
