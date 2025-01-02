using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    private Animator animator;
    private bool hasAnimationPlayed = false; 

    
    public GameObject targetObject; 
    public string scriptName1; 
    public string scriptName2; 

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
                    Invoke("EnableScripts", animator.GetCurrentAnimatorStateInfo(0).length); 
                }
            }
        }
    }

    private void EnableScripts()
    {
        if (targetObject != null)
        {
            // Включаем первый скрипт
            MonoBehaviour script1 = targetObject.GetComponent(scriptName1) as MonoBehaviour;
            if (script1 != null)
            {
                script1.enabled = true;
            }

            // Включаем второй скрипт
            MonoBehaviour script2 = targetObject.GetComponent(scriptName2) as MonoBehaviour;
            if (script2 != null)
            {
                script2.enabled = true;
            }
        }
    }
}