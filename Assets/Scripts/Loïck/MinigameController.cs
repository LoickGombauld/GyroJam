using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class MinigameController<t> : MonoBehaviour where t : MinigameBaseData
{
    [SerializeField]protected t[] _data = new t[3];
    [SerializeField] protected Difficulty _difficulty;
    private bool _isWin = false;
    protected int _currentScore = 0;
    protected bool _timerinProgress = false;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] protected Player _player;
    [SerializeField] private UnityEvent _hasWinEvent;
    [SerializeField] private UnityEvent _hasLooseEvent;

    protected abstract void StartMiniGame();
    public IEnumerator Chrono()
    {
        _timerinProgress = true;
        yield return new WaitForSeconds(CurrentData.TimeDuration);
        _timerinProgress = false;
    }

    protected t CurrentData
    {
        get
        {
            switch (_difficulty)
            {
                case Difficulty.Easy:
                    return _data[0];

                case Difficulty.Normal:
                    return _data[1];

                case Difficulty.Hard:
                    return _data[2];

                default:
                    throw new ArgumentOutOfRangeException(nameof(_difficulty), _difficulty, null);
            }
        }
    }
    public void SetDifficulty(Difficulty difficulty)
    {
        _difficulty = difficulty;
    }



    public void SetIsWin(bool hasWin)
    {
        _isWin = hasWin;
        if (hasWin)
        {
            _gameManager.WinMiniGame(_currentScore);
            _hasWinEvent.Invoke();
        }
        else
        {
            _gameManager.LooseMiniGame();
            _hasLooseEvent.Invoke();
        }
    }
}
