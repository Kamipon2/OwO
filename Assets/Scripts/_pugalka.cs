using UnityEngine;
using System.Collections; // Не забудьте добавить это пространство имен для корутин

public class Pugalka : MonoBehaviour
{
    public GameObject[] objects; 
    public GameObject targetObject; 
    public Vector3 newPosition; 
    public Quaternion newRotation; 

    public GameObject newObject; // Существующий объект, который будет перемещен
    public Transform placementObject; // Объект, на который будет ставиться новый объект

    public IaikiBolshie iaikiBolshie; 

    private bool hasMoved = false; // Переменная для отслеживания, было ли перемещение

    public AudioClip soundToPlay; // Аудиоклип, который будет воспроизводиться
    private AudioSource audioSource; // Компонент AudioSource

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Получаем компонент AudioSource
    }

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
            
            // Отключаем isKinematic у Rigidbody, если он есть
            Rigidbody rb = targetObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            // Перемещаем существующий объект на указанное место
            MoveExistingObject();

            // Воспроизводим звук
            PlaySound();

            StartCoroutine(ReturnAfterDelay()); // Запускаем корутину для задержки
            hasMoved = true; // Устанавливаем флаг, что объект был перемещен
        }
    }

    private IEnumerator ReturnAfterDelay()
    {
        yield return new WaitForSeconds(5f); // Ждем 5 секунд
        iaikiBolshie.ReturnToPreviousPosition(); // Вызываем метод возврата позиции
    }

    private void ChangeTargetObjectTransform()
    {
        if (targetObject != null)
        {
            targetObject.transform.position = newPosition;
            targetObject.transform.rotation = newRotation;
        }
    }

    private void MoveExistingObject()
    {
        if (newObject != null && placementObject != null)
        {
            // Перемещаем существующий объект на позицию объекта размещения
            newObject.transform.position = placementObject.position;
            newObject.transform.rotation = placementObject.rotation;
        }
    }

    private void PlaySound()
    {
        if (audioSource != null && soundToPlay != null)
        {
            audioSource.PlayOneShot(soundToPlay); // Воспроизводим звук
        }
        else
        {
            Debug.LogWarning("AudioSource или SoundToPlay не назначены!");
        }
    }
}
