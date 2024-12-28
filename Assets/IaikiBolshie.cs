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

            }
        }
    }
}
