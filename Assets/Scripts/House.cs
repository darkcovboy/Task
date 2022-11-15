using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] Alarm _alarm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarm.PlaySound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarm.StopPlaySound();
    }
}
