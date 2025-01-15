using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject[] targetObjects; // Массив объектов для взаимодействия
    public GameObject[] objectsToEnable; // Массив объектов, которые нужно включить
    public int sceneIndex; // Индекс сцены для загрузки
    public float interactionDistance = 3.0f; // Максимальное расстояние для взаимодействия
    public Transform cameraTarget; // Целевой объект для камеры
    public float transitionTime = 1.0f; // Время анимации перемещения камеры
    public float rotationSpeed = 5.0f; // Скорость вращения камеры
    public GameObject[] playerMeshes; // Массив мешей игрока, которые нужно отключить

    private bool isTransitioning = false; // Флаг, указывающий, происходит ли переход
    private float transitionProgress = 0f; // Прогресс перехода

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsAnyObjectInReach() && IsLookingAtAnyTarget())
            {
                StartTransition();
                DisablePlayerMeshes(); // Отключаем меши игрока при нажатии
            }
        }

        if (isTransitioning)
        {
            // Плавное перемещение камеры к целевому объекту
            transitionProgress += Time.deltaTime / transitionTime;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraTarget.position, transitionProgress);

            // Поворот камеры к целевому объекту
            Vector3 direction = (cameraTarget.position - Camera.main.transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Проверка, завершено ли перемещение
            if (transitionProgress >= 1f)
            {
                isTransitioning = false; // Завершение перехода
                SceneManager.LoadScene(sceneIndex); // Загружаем сцену
            }
        }
    }

    private void StartTransition()
    {
        isTransitioning = true; // Начинаем переход
        transitionProgress = 0f; // Сбрасываем прогресс перехода
    }

    private bool IsAnyObjectInReach()
    {
        foreach (GameObject target in targetObjects)
        {
            if (target != null)
            {
                float distanceToTarget = Vector3.Distance(Camera.main.transform.position, target.transform.position);
                if (distanceToTarget <= interactionDistance)
                {
                    return true; // Найден хотя бы один объект в пределах досягаемости
                }
            }
        }
        return false;
    }

    private bool IsLookingAtAnyTarget()
    {
        foreach (GameObject target in targetObjects)
        {
            if (target != null)
            {
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, interactionDistance))
                {
                    if (hit.collider.gameObject == target)
                    {
                        EnableCorrespondingObject(target); // Включаем соответствующий объект
                        return true; // Найдено взаимодействие с целевым объектом
                    }
                }
            }
        }
        return false;
    }

    private void EnableCorrespondingObject(GameObject target)
    {
        int index = System.Array.IndexOf(targetObjects, target);
        if (index >= 0 && index < objectsToEnable.Length)
        {
            objectsToEnable[index].SetActive(true); // Включаем соответствующий объект
        }
    }

    private void DisablePlayerMeshes()
    {
        foreach (GameObject mesh in playerMeshes)
        {
            if (mesh != null)
            {
                mesh.SetActive(false); // Отключаем меши игрока
            }
            else
            {
                Debug.LogWarning("Player mesh is not assigned!");
            }
        }
    }
}
