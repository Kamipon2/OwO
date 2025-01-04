using UnityEngine;

public class ObjectDisappear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, если объект имеет тег "DisappearingObject"
        if (other.CompareTag("DisappearingObject"))
        {
            // Скрываем объект
            other.gameObject.SetActive(false);
        }
    }
}