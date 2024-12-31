using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objects; 
    public GameObject targetObject; 
    public Vector3 newPosition; 
    public Quaternion newRotation; 

    private void Update()
    {
        if (objects.Length != 6)
        {
            Debug.LogError("Массив объектов должен содержать ровно 6 элементов.");
            return;
        }

        int disabledCount = 0;

        
        foreach (GameObject obj in objects)
        {
            if (obj == null || !obj.activeInHierarchy)
            {
                disabledCount++;
            }
        }

        
        if (disabledCount >= 3)
        {
            ChangeTargetObjectTransform();
        }
    }

    private void ChangeTargetObjectTransform()
    {
        if (targetObject != null)
        {
            targetObject.transform.position = newPosition;
            targetObject.transform.rotation = newRotation;
            Debug.Log("Позиция и поворот targetObject изменены.");
        }
        else
        {
            Debug.LogError("targetObject не задан.");
        }
    }
}