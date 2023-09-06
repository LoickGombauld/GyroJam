using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniGame 2", menuName = "MiniGame/Minigame 2", order = 1)]
public class MinigameBaseData : ScriptableObject
{
    public float TimeDuration  = 0;

    [Header("Player")]
    public float PlayerRadius = 1.0f;
    public float PlayerSpeed;
}
