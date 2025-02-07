using System;
using UnityEngine;

public class GrabManager : MonoBehaviour
{
    public float interactDistance = 3.0f; 
    public GameObject lightPoint;
    public LayerMask mask;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactDistance, mask))
        {
            Flashlight flashlight = hit.collider.GetComponent<Flashlight>();
            if (flashlight != null && !flashlight.grabActive)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    flashlight.transform.parent = lightPoint.transform;
                    flashlight.transform.localPosition = Vector3.zero;
                    flashlight.transform.localEulerAngles = Vector3.zero;
                    flashlight.grabActive = true;

                    
                    BoxCollider boxCollider = flashlight.GetComponent<BoxCollider>();
                    if (boxCollider != null)
                    {
                        boxCollider.enabled = false; 
                    }

                    // Отключаем MeshRenderer
                    MeshRenderer meshRenderer = flashlight.GetComponent<MeshRenderer>();
                    if (meshRenderer != null)
                    {
                        meshRenderer.enabled = false; 
                    }

                    Debug.Log("GrabLight");
                }
            }
        }
    }
}