using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject targetObject; // Объект, с которым будет происходить взаимодействие
    public int sceneIndex; // Индекс сцены, которую нужно загрузить
    public float interactionDistance = 3.0f; // Максимальное расстояние для взаимодействия

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsObjectInReach())
            {
                ChangeScene();
            }
        }
    }

    private bool IsObjectInReach()
    {
        // Проверяем, назначен ли целевой объект
        if (targetObject == null)
        {
            Debug.LogWarning("Target object is not assigned!");
            return false;
        }

        // Вычисляем расстояние до целевого объекта
        float distanceToTarget = Vector3.Distance(Camera.main.transform.position, targetObject.transform.position);
        
        // Проверяем, находится ли объект в пределах досягаемости
        return distanceToTarget <= interactionDistance;
    }

    private void ChangeScene()
    {
        // Загружаем сцену по индексу
        SceneManager.LoadScene(sceneIndex);
    }
}