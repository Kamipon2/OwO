using UnityEngine;

public class AnimationSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource; // Ссылка на компонент AudioSource

    // Этот метод будет вызываться из события анимации
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource не назначен!");
        }
    }
}