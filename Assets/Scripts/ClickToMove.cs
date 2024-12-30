using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public Vector3 newPosition = new Vector3(0, 1, 0);
    public Vector3 newRotationEuler = new Vector3(0, 90, 0); // Углы Эйлера для вращения
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Перемещение объекта
        transform.position = newPosition;

        // Установка нового вращения сразу
        transform.rotation = Quaternion.Euler(newRotationEuler);
    }
}