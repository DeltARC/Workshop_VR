using UnityEngine;

public class CatReact : MonoBehaviour
{
    public AudioSource angryAudioSource;
    public AudioSource petAudioSource;
    public AudioSource purrAudioSource;

    public AudioClip[] angrySounds;
    public AudioClip[] petSounds;
    public AudioClip[] purrSounds;

    private void PlayRandomSound(AudioSource source, AudioClip[] sounds)
    {
        if (sounds.Length == 0) return;

        AudioClip clip = sounds[Random.Range(0, sounds.Length)];

        source.PlayOneShot(clip);
    }

    public void PlayAngrySound()
    {
        PlayRandomSound(angryAudioSource, angrySounds);
    }

    public void StartPetting()
    {
        purrAudioSource.Stop();
        PlayRandomSound(petAudioSource, petSounds);
    }

    public void StopPetting()
    {
        purrAudioSource.Play();
    }

    public void OnTriggerEnter(Collider other)
    {
        Objects objects = other.GetComponent<Objects>();
        if (objects)
        {
            PlayAngrySound();
        }
        else
        {
            StopPetting();
        }
        Hands hands = other.GetComponent<Hands>();
        if (hands)
        {
            StartPetting();
        }
        else
        {
            StopPetting();
        }
    }
}