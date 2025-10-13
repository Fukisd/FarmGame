using UnityEngine;

public class SoilClickManager : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = Camera.main; 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                SoilTile tile = hit.collider.GetComponent<SoilTile>();
                if (tile != null)
                {
                    Debug.Log("Click vào ô đất: " + tile.name);
                    tile.OnClickTile();
                }
            }
        }
    }
}
