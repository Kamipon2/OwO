using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastGloabl : MonoBehaviour
{
    // Start is called before the first frame update
    public static RaycastHit rayGlobal;
    public Collider col;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit);
        col = hit.collider;
        if (hit.collider != null)
        {
            rayGlobal = hit;
        }
        else
        {
            //rayGlobal = null;
        }
    }
    
}
