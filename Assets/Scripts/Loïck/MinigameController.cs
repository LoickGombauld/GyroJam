using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class MinigameController<t> : MonoBehaviour where t : MinigameBaseData
{
    protected int _currentScore = 0;
    protected bool _timerinProgress = false;
    private GameManager _gameManager;
    [SerializeField] protected Player _player;
    [SerializeField] private UnityEvent _hasWinEvent;
    [SerializeField] private UnityEvent _hasLooseEvent;

    protected abstract void StartMiniGame();

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _player.SetMiniGameData(_currentData);
        StartMiniGame();
    }

    protected IEnumerator Chrono()
    {
        _timerinProgress = true;
        yield return new WaitForSeconds(_currentData.TimeDuration);
        _timerinProgress = false;
    }

    [SerializeField] protected t _currentData;


    public void SetIsWin(bool hasWin)
    {
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
        Destroy(transform.gameObject);
    }
}
