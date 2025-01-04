using UnityEngine;

public class AnimationToggle : MonoBehaviour
{
    private Animator animator;

    
    public string animationOne = "Door_open"; 
    public string animationTwo = "Door_locked"; 

    
    public float interactionDistance = 3.0f; 

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
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            
            return true; 
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
