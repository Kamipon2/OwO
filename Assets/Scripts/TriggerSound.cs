using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioClip soundToPlay; // Звук, который будет воспроизводиться
    public AudioSource audioSource; // Источник звука

    private bool hasPlayed = false; // Переменная для отслеживания, был ли звук воспроизведён

    public void StopSound() // Метод для остановки звука
    {
        audioSource.Stop();
        hasPlayed = false; // Сбрасываем флаг, чтобы звук мог воспроизводиться снова
    }

    public void DisableAudioSource() // Метод для отключения AudioSource
    {
        if (audioSource != null)
        {
            audioSource.enabled = false; // Отключаем AudioSource
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            PlaySound();
            hasPlayed = true; // Устанавливаем флаг, что звук уже воспроизведён
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