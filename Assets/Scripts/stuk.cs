using UnityEngine;

public class stuk : MonoBehaviour
{
    // Ссылка на объект, на котором находится нужный скрипт
    public GameObject targetObject;

    // Имя скрипта, который нужно активировать
    public string scriptName;

    // Аудиоисточник для воспроизведения звука
    public AudioSource audioSource;

    // Объекты, которые нужно заменить
    public GameObject[] objectsToReplace;

    // Объект, который будет заменять другие объекты
    public GameObject replacementObject;

    // Пустой GameObject, к которому нужно переместить заменённый объект
    public GameObject targetPosition;

    private MonoBehaviour targetScript;

    private void Start()
    {
        // Получаем все компоненты на целевом объекте
        MonoBehaviour[] scripts = targetObject.GetComponents<MonoBehaviour>();

        // Ищем нужный скрипт по имени
        foreach (var script in scripts)
        {
            if (script.GetType().Name == scriptName)
            {
                targetScript = script;
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, если объект имеет тег "DisappearingObject"
        if (other.CompareTag("DisappearingObject"))
        {
            // Скрываем объект
            other.gameObject.SetActive(false);

            // Воспроизводим звук, если аудиосource установлен
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Проверяем, если скрипт найден и его можно активировать
            if (targetScript != null)
            {
                // Включаем скрипт
                targetScript.enabled = true; // или вызовите нужный метод, если требуется
            }

            // Заменяем объекты на один новый объект
            ReplaceObjects();
        }
    }

    private void ReplaceObjects()
    {
        foreach (var obj in objectsToReplace)
        {
            if (obj != null)
            {
                Destroy(obj); // Уничтожаем старый объект
            }
        }

        // Создаем новый объект на позиции targetPosition
        if (replacementObject != null && targetPosition != null)
        {
            Instantiate(replacementObject, targetPosition.transform.position, Quaternion.identity);
        }
    }
}
