using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniGame 4", menuName = "MiniGame/Minigame 4 ", order = 1)]
public class TapeTaupeData : MinigameBaseData
{

    public float TaupeDelayMax;

    public float TaupeDelay => Random.Range(TaupeDelayMin, TaupeDelayMax);

    public float TaupeDelayMin;



}
public enum TaupeType
{
    Alien = 0, Bomb = 1, None = 2
}