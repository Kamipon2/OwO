using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    private Animator animator;
    private bool hasAnimationPlayed = false; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        if (!hasAnimationPlayed) 
        {
            if (animator != null)
            {
                
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

                
                if (!stateInfo.IsName("YourAnimationName")) 
                {
                    animator.SetTrigger("PlayAnimation");
                    hasAnimationPlayed = true; 
                }
            }
        }
    }
}