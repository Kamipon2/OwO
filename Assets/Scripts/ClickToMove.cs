using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public Vector3 newPosition = new Vector3(0, 1, 0);
    public Vector3 newRotationEuler = new Vector3(0, 90, 0); 
    
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

        
        transform.position = newPosition;

        
        transform.rotation = Quaternion.Euler(newRotationEuler);
    }
}