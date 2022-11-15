using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _path;
    [SerializeField] private bool _isWorking;

    private Transform[] _spawners;
    private int _spawnPoint = 0;
    private float _spawnTime = 2f;
    private WaitForSecondsRealtime waitForSecondsRealtime;


    private void Start()
    {
        _spawners = new Transform[_path.childCount];
        waitForSecondsRealtime = new WaitForSecondsRealtime(_spawnTime);

        for (int i =0; i < _path.childCount; i++)
        {
            _spawners[i] = _path.GetChild(i);
        }

        var fareJob = StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        while(_isWorking)
        {
            Instantiate(_enemy, _spawners[_spawnPoint].position, _spawners[_spawnPoint].rotation);
            _spawnPoint++;

            if (_spawnPoint > _spawners.Length - 1)
            {
                _spawnPoint = 0;
            }

            yield return waitForSecondsRealtime;
        }
    }
}
