using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class DogeProjectileController : MinigameController<DogeProjectileData>
{
    [SerializeField] private Transform[] _projectileSpot;
    [SerializeField] private GameObject _prefabsProjectile;
    public Transform CurrentProjectileSpot => _projectileSpot[Random.Range(0, _projectileSpot.Length)];

    public void StartMiniGame()
    {
        StartCoroutine(MiniGameCoroutine());
    }

    IEnumerator MiniGameCoroutine()
    {
   
        while (CurrentData.TimeDuration > 0 )
        {
            Instantiate(_prefabsProjectile);
            yield return new WaitForSeconds(CurrentData.ProjectileDelay);
        }
    }
}
