using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlackholeController : MinigameController<BlackholeData>
{
    [SerializeField] private GameObject _duckPrefab;
    private List<GameObject> _blackHoleEnemies;
    private UnityEvent _whenKillGuy;

    public void StartMiniGame()
    {
        StartCoroutine(MiniGameCoroutine());
    }

    IEnumerator MiniGameCoroutine()
    {
        yield return new WaitForSeconds(CurrentData.TimeDuration);
        

        if (CurrentData.NumEnemytoKill == 0)
        {
            _isWin = true;
        }
    }

    private void DeleteGuy(GameObject Guy)
    {
        _blackHoleEnemies.Remove(Guy);
        Destroy(Guy);
        CurrentData.NumEnemytoKill--;
    }

    public void Update()
    {
        foreach (var guy in _blackHoleEnemies)
        {
            if (_player.PlayerRadius > Vector2.Distance(guy.transform.position, _player.transform.position))
            {
               _whenKillGuy.Invoke();
            }
        }
    }
}
