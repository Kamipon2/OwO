using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public float moveRadius = 10f; // Радиус, в пределах которого персонаж будет двигаться
    public float changeDirectionTime = 3f; // Время между сменами направления

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(SetNewRandomDestination), 0f, changeDirectionTime); // Каждые несколько секунд устанавливаем новое направление
    }

    private void SetNewRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius; // Генерируем случайное направление
        randomDirection += transform.position; // Смещаем его относительно текущего положения

        NavMeshHit hit;
        // Проверяем, находится ли точка на NavMesh
        if (NavMesh.SamplePosition(randomDirection, out hit, moveRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position); // Устанавливаем новую цель
        }
    }
}