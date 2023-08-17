using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NPCAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioClip[] _audioClips;
    public void Init(AudioClip[] audioClips)
    {
        _audioClips = audioClips;
        _audioSource = GetComponent<AudioSource>();
    }


    public void PlayAudio(int currentNode)
    {
        _audioSource.clip = _audioClips[currentNode];
        _audioSource.Play();
    }
}