using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject objectToActivate; // Объект 2, который нужно активировать
    public AudioClip sound; // Звук для воспроизведения
    private AudioSource audioSource;

    public GameObject newModel; // Новая модель для объекта 1
    public Vector3 newPosition; // Новая позиция для объекта 1
    public GameObject objectToSwap; // Объект, с которым будет производиться замена
    public Vector3 swapRotation; // Поворот, который будет применен к объекту для замены

    private bool hasInteracted = false; // Флаг, чтобы отслеживать, было ли взаимодействие

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Добавляем компонент AudioSource
        audioSource.clip = sound; // Устанавливаем звук
    }

    private void OnMouseDown()
    {
        // Вызываем метод Interact при нажатии на объект 1, только если еще не взаимодействовали
        if (!hasInteracted)
        {
            Interact();
        }
    }

    private void Interact()
    {
        hasInteracted = true; // Устанавливаем флаг взаимодействия в true

        // Активируем объект 2
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true); // Включаем объект 2
            Invoke("HideObject", 2f); // Запускаем метод HideObject через 2 секунды
        }

        // Воспроизводим звук
        audioSource.Play();

        // Меняем модель и позицию объекта 1
        ChangeModelAndPosition();
    }

    private void HideObject()
    {
        // Отключаем объект 2
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
    }

    private void ChangeModelAndPosition()
    {
        // Сохраняем текущую позицию и вращение объекта 1
        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;

        // Меняем модель объекта 1
        if (newModel != null)
        {
            Destroy(transform.GetChild(0).gameObject); // Удаляем текущую модель (предполагается, что она первая дочерняя)
            Instantiate(newModel, currentPosition, currentRotation, transform); // Создаем новую модель
        }

        // Проверяем, есть ли объект для замены
        if (objectToSwap != null)
        {
            // Сохраняем позицию объекта для замены
            Vector3 swapPosition = objectToSwap.transform.position;

            // Меняем местами объект 1 и объект для замены
            objectToSwap.transform.position = currentPosition;
            objectToSwap.transform.rotation = Quaternion.Euler(swapRotation); // Применяем заданный поворот к объекту для замены

            transform.position = swapPosition;
            transform.rotation = currentRotation;
        }
    }
}
