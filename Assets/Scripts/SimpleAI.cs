using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    public float moveRadius = 10f; // Радиус, в пределах которого персонаж будет двигаться
    public float changeDirectionTime = 3f; // Время между сменами направления

    private NavMeshAgent agent;
    private Animator animator; // Ссылка на компонент Animator

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Получаем компонент Animator
        InvokeRepeating(nameof(SetNewRandomDestination), 0f, changeDirectionTime); // Каждые несколько секунд устанавливаем новое направление
    }

    private void Update()
    {
        // Проверяем, движется ли агент
        if (agent.velocity.magnitude > 0.1f) // Если скорость больше 0.1, значит, персонаж движется
        {
            animator.SetBool("isMoving", true); // Устанавливаем параметр isMoving в true
        }
        else
        {
            animator.SetBool("isMoving", false); // Устанавливаем параметр isMoving в false
        }
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