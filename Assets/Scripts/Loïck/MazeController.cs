using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MinigameController<MazeData>
{

    private bool _hasArrived = false;
    protected override void StartMiniGame()
    {
        StartCoroutine(Chrono());
        StartCoroutine(MiniGameCoroutine());
    }

    IEnumerator MiniGameCoroutine()
    {
        yield return new WaitUntil((() => _timerinProgress ||_hasArrived));
        if (_hasArrived)
        {
            SetIsWin(true);
        }
        else
        {
            SetIsWin(false);
        }
    }
}
