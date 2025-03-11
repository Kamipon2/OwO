using UnityEngine;

public class spat : MonoBehaviour
{
    public GameObject player; 
    public Transform Point; 

    private Vector3 previousPlayerPosition; 
    private Vector3 previousCameraPosition; 

    private bool hasMoved = false; 

    void Start()
    {
        SaveCurrentPositions();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasMoved)
        {
            if (RayCastGloabl.rayGlobal.collider.name == gameObject.name)
            {
                SaveCurrentPositions();
                
                MovePlayerToPoint();
                hasMoved = true; 
            }
        }
    }
    
    private void SaveCurrentPositions()
    {
        previousPlayerPosition = player.transform.position;
        previousCameraPosition = player.GetComponentInChildren<Camera>().transform.position;
    }
    
    private void MovePlayerToPoint()
    {
        LeanTween.move(player.GetComponentInChildren<Camera>().gameObject, Point.position, 1f);
        LeanTween.rotate(player.GetComponentInChildren<Camera>().gameObject, new Vector3(0, 0, 0), 1f);
        
        player.GetComponentInChildren<FirstPersonLook>().enabled = false;
        player.GetComponentInChildren<MeshRenderer>().enabled = false;
        player.GetComponent<FirstPersonMovement>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<MeshCollider>().enabled = false;
        
        Cursor.lockState = CursorLockMode.None; 
        
    }
    
    public void ReturnToPreviousPosition()
    {
        player.GetComponentInChildren<Camera>().transform.localPosition = new Vector3(0f, 1.48800004f, 0f);
        
        player.GetComponentInChildren<FirstPersonLook>().enabled = true;
        player.GetComponentInChildren<MeshRenderer>().enabled = true;
        player.GetComponent<FirstPersonMovement>().enabled = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<MeshCollider>().enabled = true;
        
        Cursor.lockState = CursorLockMode.Locked; 
        
    }
}
