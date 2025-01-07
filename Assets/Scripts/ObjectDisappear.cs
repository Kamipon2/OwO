using UnityEngine;

public class ObjectDisappear : MonoBehaviour
{
    // Ссылка на объект, на котором находится нужный скрипт
    public GameObject targetObject;

    // Имя скрипта, который нужно активировать
    public string scriptName;

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

            // Проверяем, если скрипт найден и его можно активировать
            if (targetScript != null)
            {
                // Включаем скрипт
                targetScript.enabled = true; // или вызовите нужный метод, если требуется
            }
        }
    }
}