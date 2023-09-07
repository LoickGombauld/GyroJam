using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _bossLife = 3;
    [SerializeField] private int _playerLife = 3;
    
    [SerializeField] private UnityEventSequencer _eventWinMiniGame;
    [SerializeField] private UnityEventSequencer _eventLooseminiGame;
    private int _score = 0;
    [SerializeField] private string _name = "Larry";

    [SerializeField]private List<MinigameBaseData> _minigames;


    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void WinMiniGame(int score)
    {
        _score += score ;
        _eventWinMiniGame.StartSequence();
    }

    public void LooseMiniGame()
    {
        _eventLooseminiGame.StartSequence();
        _playerLife--;
    }

    public void RemoveBossLife()
    {
        _bossLife--;
    }

    public void SetName(string name)
    {
        _name = name;
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}


public enum Difficulty
{
    Easy = 0, Normal = 1, Hard = 2
}

