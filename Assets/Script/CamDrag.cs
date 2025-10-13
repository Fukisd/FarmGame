using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 0.1f;

    private Vector3 lastMousePos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePos;

            // Lấy hướng ngang (right) và dọc (forward) theo camera
            Vector3 right = transform.right;
            Vector3 forward = transform.forward;

            // Bỏ thành phần Y để camera chỉ di chuyển trong mặt phẳng XZ
            right.y = 0;
            forward.y = 0;
            right.Normalize();
            forward.Normalize();

            // Tính vector di chuyển dựa trên delta chuột
            Vector3 move = (-right * delta.x - forward * delta.y) * dragSpeed;

            transform.position += move;

            lastMousePos = Input.mousePosition;
        }
    }
}
