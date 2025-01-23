using UnityEngine;

public class DisableAfterAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Проверяем, есть ли анимации и закончилась ли текущая анимация
        if (animator != null && !animator.GetCurrentAnimatorStateInfo(0).loop)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                // Отключаем объект
                gameObject.SetActive(false);
            }
        }
    }
}