using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public Vector3 newRotationEuler = new Vector3(0, 90, 0); 
    public Camera cam;
    public float rasstoianie;
    public IaikiBolshie iaikiBolshie; // Ссылка на IaikiBolshie
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + rasstoianie);
        transform.rotation = Quaternion.Euler(newRotationEuler);
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