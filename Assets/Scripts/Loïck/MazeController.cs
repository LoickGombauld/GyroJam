using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MinigameController<MazeData>
{
    private bool _hasArrived = false;

    [SerializeField] private GameObject _exit;
    protected override void StartMiniGame()
    {
        StartCoroutine(Chrono());
        StartCoroutine(MiniGameCoroutine());
    }

    IEnumerator MiniGameCoroutine()
    {
        yield return new WaitUntil((() => !_timerinProgress || _hasArrived|| _player.isKill));

        if (_hasArrived)
        {
            SetIsWin(true);
        }
        else
        {
            SetIsWin(false);
        }
    }

    private void Update()
    {
        if (Vector2.Distance( _player.transform.position, _exit.transform.position)< _player.PlayerRadius)
        {
            _hasArrived = true;
        }
    }


}
