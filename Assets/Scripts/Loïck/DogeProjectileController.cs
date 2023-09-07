using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class DogeProjectileController : MinigameController<DogeProjectileData>
{
    [SerializeField] private Transform[] _projectileSpot;
    [SerializeField] private GameObject _prefabsProjectile;
    public Transform CurrentProjectileSpot => _projectileSpot[Random.Range(0, _projectileSpot.Length)];
    [SerializeField] private UnityEvent _whenProjectilespawnEvent;
    protected override void StartMiniGame()
    {
        StartCoroutine(Chrono());
        StartCoroutine(MiniGameCoroutine());
    }

    IEnumerator MiniGameCoroutine()
    {
   
        while (_timerinProgress)
        {
            _whenProjectilespawnEvent.Invoke();
            _currentScore += 20;
            Instantiate(_prefabsProjectile);
            yield return new WaitForSeconds(_currentData.ProjectileDelay);
        }
        SetIsWin(true);
    }

    private void Update()
    {
        if (_currentData)
        {
            
        }
    }
}
