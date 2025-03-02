using UnityEngine;

public class PlayerCameraInteraction : MonoBehaviour
{
    public GameObject[] interactableObjects; 
    public GameObject objectToActivate; 
    public GameObject objectToDeactivate; 
    public AudioClip destroySound; 
    private AudioSource audioSource; 
    public float interactionDistance = 5f; 
    public float holdTime = 3f; 
    private float timer = 0f; 
    private bool isHolding = false; 
    private GameObject currentInteractable; 
    private int destroyedCount = 0; 

    public GameObject animatorObject; 
    private Animator animator; 

    // Добавляем ссылку на SceneChanger
    public SceneChanger sceneChanger; // Убедитесь, что этот объект назначен в инспекторе

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); 
        audioSource.clip = destroySound;

        if (animatorObject != null)
        {
            animator = animatorObject.GetComponent<Animator>();
        }

        // Убедитесь, что SceneChanger отключен в начале
        if (sceneChanger != null)
        {
            sceneChanger.enabled = false;
        }
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            foreach (GameObject obj in interactableObjects)
            {
                if (hit.collider.gameObject == obj)
                {
                    currentInteractable = obj; 
                    
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        isHolding = true; 
                        timer = 0f; 
                        
                        if (objectToActivate != null)
                        {
                            objectToActivate.SetActive(true);
                        }
                    }

                    if (isHolding)
                    {
                        timer += Time.deltaTime; 

                        if (timer >= holdTime)
                        {
                            Destroy(currentInteractable);
                            destroyedCount++; 
                            
                            if (destroyedCount == 5)
                            {
                                audioSource.Play();
                                
                                if (objectToDeactivate != null)
                                {
                                    objectToDeactivate.SetActive(false);
                                }
                            }
                            
                            if (destroyedCount == 15 && animator != null)
                            {
                                animator.enabled = true;
                            }

                            // Проверяем, уничтожен ли 26-й объект
                            if (destroyedCount == 26 && sceneChanger != null)
                            {
                                sceneChanger.enabled = true; // Включаем скрипт SceneChanger
                            }

                            ResetInteraction(); 
                            
                            if (objectToActivate != null)
                            {
                                objectToActivate.SetActive(false);
                            }
                        }
                    }
                    
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        isHolding = false;
                        timer = 0f; 
                        
                        if (objectToActivate != null)
                        {
                            objectToActivate.SetActive(false);
                        }
                        ResetInteraction();
                    }

                    return; 
                }
            }
        }
        ResetInteraction();
    } 

    private void ResetInteraction()
    {
        currentInteractable = null; 
        isHolding = false; 
        timer = 0f; 
    }
}
