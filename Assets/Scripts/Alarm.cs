using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private readonly float _recoveryRate = 0.3f;

    public void PlaySound()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
        _audioSource.volume = 0;
        StopCoroutine(ChangeSound()); ;
        var sound = StartCoroutine(ChangeSound());
    }

    public void StopPlaySound()
    {
        StopCoroutine(ChangeSound());
        var sound = StartCoroutine(ChangeSound());
    }

    private IEnumerator ChangeSound()
    {
        if (_audioSource.volume == 0)
        {
            while (_audioSource.volume < 1)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, _recoveryRate * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            while (_audioSource.volume > 0)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, _recoveryRate * Time.deltaTime * (-1));
                yield return null;
            }
        }
    }
}
