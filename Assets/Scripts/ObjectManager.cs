using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objects; 
    public GameObject targetObject; 
    public Vector3 newPosition; 
    public Quaternion newRotation; 

    public IaikiBolshie iaikiBolshie; 

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

        // Если 3 или более объектов отключены, вызываем метод из IaikiBolshie
        if (disabledCount >= 3)
        {
            ChangeTargetObjectTransform();
            iaikiBolshie.ReturnToPreviousPosition(); // Вызываем метод возврата позиции
            
            // Отключаем isKinematic у Rigidbody объекта Otchet
            GameObject otchetObject = GameObject.Find("Otchet");
            if (otchetObject != null)
            {
                Rigidbody otchetRigidbody = otchetObject.GetComponent<Rigidbody>();
                if (otchetRigidbody != null)
                {
                    otchetRigidbody.isKinematic = false; // Отключаем isKinematic
                }
            }
        }
    }

    private void ChangeTargetObjectTransform()
    {
        if (targetObject != null)
        {
            targetObject.transform.position = newPosition;
            targetObject.transform.rotation = newRotation;
        }
    }
}