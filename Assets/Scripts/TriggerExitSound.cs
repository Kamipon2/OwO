using UnityEngine;

public class TriggerExitSound : MonoBehaviour
{
    public AudioClip soundToPlay; // Звук, который будет воспроизводиться
    public AudioSource audioSource; // Источник звука

    private bool hasPlayed = false; // Переменная для отслеживания, был ли звук воспроизведён

    public TriggerSound triggerSound; // Ссылка на первый скрипт

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Telephone") && !hasPlayed)
        {
            if (triggerSound != null)
            {
                triggerSound.StopSound(); // Останавливаем звук из первого скрипта
                triggerSound.DisableAudioSource(); // Отключаем AudioSource в первом скрипте
            }
            PlaySound();
            hasPlayed = true; 
        }
    }

    private void PlaySound()
    {
        if (soundToPlay != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundToPlay);
        }
    }
}