using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public Vector3 newRotationEuler = new Vector3(0, 90, 0); 
    public Camera cam;
    public float rasstoianie;
    public IaikiBolshie iaikiBolshie; // Ссылка на IaikiBolshie
    private Rigidbody rb;

    private bool hasMoved = false; // Переменная для отслеживания, было ли перемещение

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        // Проверяем, было ли уже перемещение
        if (!hasMoved)
        {
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + rasstoianie);
            transform.rotation = Quaternion.Euler(newRotationEuler);

            hasMoved = true; // Устанавливаем флаг, что объект был перемещен
        }
    }

    // Метод для отключения isKinematic
    public void DisableKinematic()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}