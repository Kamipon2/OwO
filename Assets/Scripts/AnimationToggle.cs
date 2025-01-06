using UnityEngine;

public class AnimationToggle : MonoBehaviour
{
    private Animator animator;

    public string animationOne = "Door_open"; 
    public string animationTwo = "Door_locked"; 

    public float interactionDistance = 3.0f; 

    
    public GameObject targetObject;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsObjectInReach())
            {
                ToggleAnimation();
            }
        }
    }

    private bool IsObjectInReach()
    {
        
        if (targetObject == null)
        {
            Debug.LogWarning("Target object is not assigned!");
            return false;
        }

        
        float distanceToTarget = Vector3.Distance(Camera.main.transform.position, targetObject.transform.position);
        
        
        return distanceToTarget <= interactionDistance;
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