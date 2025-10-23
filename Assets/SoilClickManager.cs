using UnityEngine;

public class SoilClickManager : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = Camera.main; // lấy camera chính
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // click chuột trái
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Kiểm tra có phải đất không
                SoilTile tile = hit.collider.GetComponent<SoilTile>();
                if (tile != null)
                {
                    Debug.Log("Click vào ô đất: " + tile.name);
                    tile.OnClickTile(); // Gọi hàm xử lý trong SoilTile
                }
            }
        }
    }
}
