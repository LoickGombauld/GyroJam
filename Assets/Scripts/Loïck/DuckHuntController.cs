using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DuckHuntController : MinigameController<DuckHuntData>
{
    [SerializeField] private GameObject _duckPrefab;
    private List<GameObject> _ducks;


    protected override void StartMiniGame()
    {
        StartCoroutine(Chrono());
        StartCoroutine(MiniGameCoroutine());
    }


    IEnumerator MiniGameCoroutine()
    {
        while (_timerinProgress || CurrentData.NumDucktoKill > 0)
        {
            _ducks.Add(Instantiate(_duckPrefab));

            yield return new WaitForSeconds(CurrentData.DuckDelay);
        }

        if (CurrentData.NumDucktoKill <= 0)
        {
            for (int i = 0; i < CurrentData.TimeDuration; i++)
            {
                _currentScore += 20;
            }
            SetIsWin(true);
        }
        else
        {
            SetIsWin(false);
        }
    }

    private void DeleteDuck(GameObject duck)
    {
        _ducks.Remove(duck);
        Destroy(duck);
        CurrentData.NumDucktoKill--;
    }

    public void Update()
    {
        foreach (var duck in _ducks)
        {
            if (_player.PlayerRadius > Vector2.Distance(duck.transform.position, _player.transform.position))
            {
                DeleteDuck(duck);
            }
        }
    }
}

