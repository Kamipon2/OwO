using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaikiBolshie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Transform Point;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(RayCastGloabl.rayGlobal.collider.name == gameObject.name)
            {
                LeanTween.move(player.GetComponentInChildren<Camera>().gameObject, Point.position, 1f);
                LeanTween.rotate(player.GetComponentInChildren<Camera>().gameObject, new Vector3(0,0,0), 1f);
                player.GetComponentInChildren<FirstPersonLook>().enabled = false;
                player.GetComponentInChildren<MeshRenderer>().enabled = false;
                player.GetComponent<FirstPersonMovement>().enabled = false;
                player.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<MeshCollider>().enabled = false;
                Screen.lockCursor = false;
                Cursor.visible = true;
            }
        }
    }
}
