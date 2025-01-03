using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objects; 
    public GameObject targetObject; 
    public Vector3 newPosition; 
    public Quaternion newRotation; 

    public IaikiBolshie iaikiBolshie; 

    private bool hasMoved = false; // Переменная для отслеживания, было ли перемещение

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

        // Если 3 или более объектов отключены и объект еще не перемещен
        if (disabledCount >= 3 && !hasMoved)
        {
            ChangeTargetObjectTransform();
            iaikiBolshie.ReturnToPreviousPosition(); // Вызываем метод возврата позиции
            
            // Отключаем isKinematic у Rigidbody, если он есть
            Rigidbody rb = targetObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            hasMoved = true; // Устанавливаем флаг, что объект был перемещен
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