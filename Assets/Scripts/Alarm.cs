using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private readonly float _recoveryRate = 0.3f;

    public void PlaySound()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
        _audioSource.volume = 0;
        StopCoroutine(ChangeSound(_recoveryRate)); ;
        var sound = StartCoroutine(ChangeSound(_recoveryRate));
    }

    public void StopPlaySound()
    {
        StopCoroutine(ChangeSound(-_recoveryRate));
        var sound = StartCoroutine(ChangeSound(-_recoveryRate));
    }

    private IEnumerator ChangeSound(float recoveryRate)
    {
        while (_audioSource.volume > 0 || _audioSource.volume < 1)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, recoveryRate * Time.deltaTime * (-1));
            yield return null;
        }
    }
}
