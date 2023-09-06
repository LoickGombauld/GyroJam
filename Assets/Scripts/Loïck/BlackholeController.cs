using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeController : MinigameController<BlackholeData>
{
    [SerializeField] private GameObject _duckPrefab;
    private List<GameObject> _blackHoleEnemies;


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

    private void DeleteDuck(GameObject duck)
    {
        _blackHoleEnemies.Remove(duck);
        Destroy(duck);
        CurrentData.NumEnemytoKill--;
    }

    public void Update()
    {
        foreach (var duck in _blackHoleEnemies)
        {
            if (_player.PlayerRadius > Vector2.Distance(duck.transform.position, _player.transform.position))
            {
                DeleteDuck(duck);
            }
        }
    }
}
