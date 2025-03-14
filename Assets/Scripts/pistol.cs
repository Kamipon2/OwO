using UnityEngine;
using UnityEngine.SceneManagement; // Не забудьте добавить это пространство имен

public class TriggerAnimator : MonoBehaviour
{
    // Ссылка на объект с Animator
    public GameObject objectWithAnimator;

    // Ссылка на объект, который нужно включить
    public GameObject objectToActivate;

    // Индекс сцены для смены
    public int sceneIndexToLoad;

    // Время ожидания перед активацией объекта и сменой сцены
    private float activationDelay = 4f; // Задержка активации объекта
    private float sceneChangeDelay = 2f; // Задержка смены сцены
    private float timer;
    private bool isTimerRunning = false;
    private bool isObjectActivated = false; // Флаг для отслеживания активации объекта

    // Метод, который будет вызываться при входе в триггер
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что триггер касается объекта с тегом "Player"
        if (other.CompareTag("Player"))
        {
            // Получаем компонент Animator у указанного объекта
            Animator animator = objectWithAnimator.GetComponent<Animator>();

            // Проверяем, что компонент Animator существует
            if (animator != null)
            {
                // Включаем анимацию
                animator.enabled = true;
            }
            else
            {
                Debug.LogWarning("Animator не найден на объекте: " + objectWithAnimator.name);
            }

            // Запускаем таймер для активации объекта
            timer = activationDelay;
            isTimerRunning = true;
        }
    }

    private void Update()
    {
        // Если таймер запущен, уменьшаем его значение
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;

            // Если таймер достиг нуля и объект еще не активирован, активируем его
            if (timer <= 0f && !isObjectActivated)
            {
                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(true);
                    isObjectActivated = true; // Устанавливаем флаг активации объекта
                }
                else
                {
                    Debug.LogWarning("Объект для активации не задан.");
                }

                // Запускаем таймер для смены сцены после активации объекта
                timer = sceneChangeDelay;
            }

            // Если таймер для смены сцены достиг нуля, меняем сцену
            if (isObjectActivated && timer <= 0f)
            {
                SceneManager.LoadScene(sceneIndexToLoad);
            }
        }
    }
}
