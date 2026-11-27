
using UnityEngine;

public class TestCatReact : MonoBehaviour
{
    [Header("Angry Sounds")]
    public AudioSource angryAudioSource;
    public AudioClip[] angrySounds;

    [Header("Petting Sounds")]
    public AudioSource petAudioSource;
    public AudioClip[] petSounds;

    [Header("Special Sound")]
    public AudioSource specialAudioSource;
    public AudioClip specialSound;
    [Range(0f, 1f)]
    public float specialSoundChance = 0.15f;

    private void PlayRandomSound(AudioSource source, AudioClip[] sounds)
    {
        if (sounds.Length == 0 || source == null) return;

        AudioClip clip = sounds[Random.Range(0, sounds.Length)];
        source.PlayOneShot(clip);
    }

    public void PlayAngrySound()
    {
        PlayRandomSound(angryAudioSource, angrySounds);
    }

    public void StartPetting()
    {
        PlayRandomSound(petAudioSource, petSounds);

        if (specialAudioSource != null &&
            specialSound != null &&
            Random.value <= specialSoundChance)
        {
            specialAudioSource.PlayOneShot(specialSound);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Objects objects = other.GetComponent<Objects>();

        if (objects != null)
        {
            PlayAngrySound();
            return;
        }

        Hands hands = other.GetComponentInParent<Hands>();

        if (hands != null)
        {
            StartPetting();
        }
    }
}
