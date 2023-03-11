using System;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; // Array of sounds
    public static AudioManager Instance { get; private set; } // Static link

    private void Awake()
    {
        if (Instance == null)
            Instance = this; // Setup static link
        else
        {
            Destroy(gameObject); // Should destroy if it`s already has manager 
            return;
        }
        
        // Move object to Dont Destroy On Load
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(string soundName)
    {
        // Try to find sound by name
        var sound = sounds.FirstOrDefault(e => e.name == soundName);
        if (sound == null)
        {
            Debug.Log($"<color=red> No Sound: {soundName}</color>");
            return;
        }
        
        // Create and setup audio source
        var source = gameObject.AddComponent<AudioSource>();
        source.loop = sound.loop;
        source.clip = sound.audioClip;
        source.volume = sound.volume;
        source.pitch = sound.pitch;
        source.spatialBlend = sound.spaceSound;
        source.Play();
        
        if (!sound.loop)
            Destroy(source, sound.audioClip.length);
    }
    
}

[Serializable]
public class Sound
{
    // Sound Parameters
    
    public string name; // Name of sounds
    public bool loop; // Loop
    [Range(0f, 1f)]
    public float volume; // Volume of sound
    public float pitch; // Pitch of sound
    [Range(0f, 1f)]
    public float spaceSound; // Spatial blend of sound
    public AudioClip audioClip; // Clip
}
