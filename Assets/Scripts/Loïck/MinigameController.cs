using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController<t> : MonoBehaviour
{
   protected  t[] _data = new t[3];
   protected Difficulty _difficulty;
   protected bool _isWin = false;
   [SerializeField] protected Player _player;

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

   public void SetIsWin(bool hasWin )
   {
        _isWin = hasWin;
   }
}
