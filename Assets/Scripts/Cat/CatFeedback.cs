
using UnityEngine;

public class CatFeedback : MonoBehaviour
{
    [Header("Petting Sounds")]
    public AudioSource petAudioSource;
    public AudioClip[] petSounds;

    [Header("Angry Sounds")]
    public AudioSource angryAudioSource;
    public AudioClip[] angrySounds;

    [Header("Special Reaction")]
    public AudioSource specialAudioSource;
    public AudioClip specialSound;
    [Range(0f, 1f)]
    public float specialChance = 0.1f;
    public float rotationDuration = 2f;

    private bool isRotating = false;

    private void PlayRandomSound(AudioSource source, AudioClip[] sounds)
    {
        if (source == null || sounds == null || sounds.Length == 0) return;

        AudioClip clip = sounds[Random.Range(0, sounds.Length)];
        source.PlayOneShot(clip);
    }

    public void PlayAngrySound()
    {
        PlayRandomSound(angryAudioSource, angrySounds);
    }

    public void StartPetting()
    {
        if (petSounds.Length > 0 && petAudioSource != null)
        {
            AudioClip clip = petSounds[Random.Range(0, petSounds.Length)];
            petAudioSource.PlayOneShot(clip);
        }

        if (!isRotating && Random.value < specialChance)
        {
            if (specialAudioSource != null && specialSound != null)
                specialAudioSource.PlayOneShot(specialSound);

            StartCoroutine(RotateCat());
        }
    }

    private System.Collections.IEnumerator RotateCat()
    {
        isRotating = true;
        float elapsedTime = 0f;
        float rotationSpeed = 720f / rotationDuration;

        while (elapsedTime < rotationDuration)
        {
            float rotation = rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotation, 0f, Space.Self);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isRotating = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
            return;

        PlayAngrySound();
    }
}
