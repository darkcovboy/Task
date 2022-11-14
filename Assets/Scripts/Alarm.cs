using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private readonly float _recoveryRate = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
            _audioSource.volume = 0;

            StopCoroutine(DecreaseSound()); ;
            var increaseSound = StartCoroutine(IncreaseSound());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(IncreaseSound());
        _audioSource.Play();
        var decreaseSound = StartCoroutine(DecreaseSound());
    }

    private IEnumerator IncreaseSound()
    {
        while (_audioSource.volume < 1)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DecreaseSound()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, _recoveryRate * Time.deltaTime *(-1));
            yield return null;
        }
    }
}
