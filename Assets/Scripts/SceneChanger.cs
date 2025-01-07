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
            if (IsObjectInReach() && IsLookingAtTarget())
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

    private bool IsLookingAtTarget()
    {
        if (targetObject == null)
        {
            return false;
        }

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // Выполняем Raycast и проверяем, попадает ли он на целевой объект
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            return hit.collider.gameObject == targetObject;
        }

        return false;
    }

    private void ChangeScene()
    {
        // Загружаем сцену по индексу
        SceneManager.LoadScene(sceneIndex);
    }
}