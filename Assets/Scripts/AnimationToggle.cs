using UnityEngine;

public class AnimationToggle : MonoBehaviour
{
    private Animator animator;

    public string animationOne = "Door_open"; // Имя первой анимации
    public string animationTwo = "Door_locked"; // Имя второй анимации

    public float interactionDistance = 3.0f; // Максимальное расстояние для взаимодействия

    public GameObject targetObject; // Целевой объект, на который игрок должен смотреть

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (targetObject == null)
        {
            Debug.LogWarning("Target object is not assigned! Please assign a target object in the inspector.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsObjectInReach() && IsLookingAtTarget())
            {
                ToggleAnimation();
            }
        }
    }

    private bool IsObjectInReach()
    {
        if (targetObject == null)
        {
            return false;
        }

        float distanceToTarget = Vector3.Distance(Camera.main.transform.position, targetObject.transform.position);
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

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            return hit.collider.gameObject == targetObject;
        }

        return false;
    }

    private void ToggleAnimation()
    {
        var currentState = animator.GetCurrentAnimatorStateInfo(0);

        if (currentState.IsName(animationOne) && currentState.normalizedTime >= 1.0f)
        {
            animator.Play(animationTwo);
        }
        else if (currentState.IsName(animationTwo) && currentState.normalizedTime >= 1.0f)
        {
            animator.Play(animationOne);
        }
        else if (!currentState.IsName(animationOne) && !currentState.IsName(animationTwo))
        {
            animator.Play(animationOne);
        }
    }
}
