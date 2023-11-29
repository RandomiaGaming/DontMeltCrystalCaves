using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public List<AudioClip> Songs = new List<AudioClip>();

    private List<AudioClip> _playlist = new List<AudioClip>();
    private AudioSource _audioSource = null;
    private int _currentClipIndex = 0;
    private void Start()
    {
        List<AudioClip> selectQue = new List<AudioClip>(Songs);

        _playlist = new List<AudioClip>();

        while (selectQue.Count > 0)
        {
            int i = RandomnessHelper.NextInt(0, selectQue.Count - 1);
            _playlist.Add(selectQue[i]);
            selectQue.RemoveAt(i);
        }

        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _playlist[_currentClipIndex];
        _audioSource.loop = false;
        _audioSource.Play();
    }
    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            _currentClipIndex++;

            if(_currentClipIndex >= _playlist.Count)
            {
                _currentClipIndex = 0;
            }

            _audioSource.clip = _playlist[_currentClipIndex];
            _audioSource.Play();
        }
    }
}
