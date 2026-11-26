using UnityEngine;

public class RadioController : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] playlist;

    private int currentTrack = 0;

    private void Start()
    {
        if (playlist.Length > 0)
        {
            PlayTrack(currentTrack);
        }
    }

    public void NextTrack()
    {
        currentTrack++;

        if (currentTrack >= playlist.Length)
        {
            currentTrack = 0;
        }

        PlayTrack(currentTrack);
    }

    public void PreviousTrack()
    {
        currentTrack--;

        if (currentTrack < 0)
        {
            currentTrack = playlist.Length - 1;
        }

        PlayTrack(currentTrack);
    }

    private void PlayTrack(int index)
    {
        audioSource.clip = playlist[index];
        audioSource.Play();
    }
}