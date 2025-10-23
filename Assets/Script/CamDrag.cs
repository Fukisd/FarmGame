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

            Vector3 right = transform.right;
            Vector3 forward = transform.forward;

            right.y = 0;
            forward.y = 0;
            right.Normalize();
            forward.Normalize();

            Vector3 move = (-right * delta.x - forward * delta.y) * dragSpeed;

            transform.position += move;

            lastMousePos = Input.mousePosition;
        }
    }
}
