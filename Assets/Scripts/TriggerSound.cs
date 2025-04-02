using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioClip soundToPlay;
    public AudioSource audioSource; 

    private bool hasPlayed = false; 

    public void StopSound() 
    {
        audioSource.Stop();
        hasPlayed = false; 
    }

    public void DisableAudioSource() 
    {
        if (audioSource != null)
        {
            audioSource.enabled = false; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
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