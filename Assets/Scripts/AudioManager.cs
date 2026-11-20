using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        
        print($"Sound currently playing: {clip.name}");
    }
    
}
