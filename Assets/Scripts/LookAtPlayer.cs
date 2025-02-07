using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    // Ссылка на игрока
    public Transform player;

    // Скорость вращения
    public float rotationSpeed = 5f;

    void Update()
    {
        if (player != null)
        {
            // Вычисляем направление к игроку
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Игнорируем вертикальную ось

            // Проверяем, что направление не нулевое
            if (direction.magnitude > 0.1f)
            {
                // Вычисляем целевое вращение
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Создаем новое вращение с фиксированным углом по оси X
                targetRotation *= Quaternion.Euler(-90f, 0f, 0f);

                // Поворачиваем объект к целевому вращению с заданной скоростью
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}