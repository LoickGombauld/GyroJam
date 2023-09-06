using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniGame 1", menuName = "MiniGame/MiniGame 1", order = 1)]
public class DogeProjectileData : MinigameBaseData
{

    public float ProjectileSpeed;

    public float ProjectileDelayMax;

    public float ProjectileDelay => Random.Range(ProjectileDelayMin,ProjectileDelayMax);
    
    public float ProjectileDelayMin;

    public float ProjectileLifeTime;
}
