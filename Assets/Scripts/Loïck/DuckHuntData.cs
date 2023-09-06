using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "MiniGame 5", menuName = "MiniGame/MiniGame 5", order = 1)]
public class DuckHuntData : MinigameBaseData
{
    public int NumDucktoKill = 3;

    public float DuckDelayMax;

    public float DuckDelay => Random.Range(DuckDelayMin, DuckDelayMax);

    public float DuckDelayMin;
}
