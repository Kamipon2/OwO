using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Получаем компонент Animator
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        // Воспроизводим анимацию при нажатии на объект
        if (animator != null)
        {
            animator.SetTrigger("PlayAnimation");
        }
    }
}