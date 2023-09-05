using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [SerializeField] private int _bossLife = 3;
   [SerializeField] private int _playerLife = 3;

   [SerializeField] private float _time = 0;
   private int _score = 0;
   [SerializeField] private string _name = "Larry";
   private void Start()
   {
       DontDestroyOnLoad(this);
   }


   public void SetName(string name)
   {
       _name = name;
   }

   public void AddScore(int addtionScore)
   {
       _score += addtionScore;
   }

  public void LoadScene(string sceneName)
   {
       SceneManager.LoadScene(sceneName);
   }



}


