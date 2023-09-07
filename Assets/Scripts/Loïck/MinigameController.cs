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
    private int _second = 0;
    protected abstract void StartMiniGame();

    private void Start()
    {
        _second = _currentData.TimeDuration;
        _gameManager = GameManager.Instance;
        _player.SetMiniGameData(_currentData);
        StartMiniGame();
    }

    protected IEnumerator Chrono()
    {
        _timerinProgress = true;
        
        while (_second == 0)
        {
            _second--;
            yield return new WaitForSeconds(1);
        }
        _timerinProgress = false;
    }

    [SerializeField] protected t _currentData;


    public void SetIsWin(bool hasWin)
    {
        if (hasWin)
        {
            for (int i = 0; i < _second; i++)
            {
                _currentScore += 20;
            }
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
