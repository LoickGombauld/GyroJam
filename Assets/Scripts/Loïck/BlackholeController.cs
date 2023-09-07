using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class BlackholeController : MinigameController<BlackholeData>
{
    [SerializeField] private GameObject _guyPrefab;
    private List<GameObject> _blackHoleEnemies;
    private UnityEvent _whenKillGy;

    protected override void StartMiniGame()
    {
        StartCoroutine(Chrono());
        StartCoroutine(MiniGameCoroutine());
    }

    IEnumerator MiniGameCoroutine()
    {
        for (int i = 0; i < _currentData.NumEnemytoKill  ; i++)
        {
            Vector3 randomposition = Random.insideUnitCircle * _currentData.SpawnRange;
            GameObject guy = Instantiate(_guyPrefab);
            guy.transform.position = randomposition;
            _blackHoleEnemies.Add(guy);
        }

        yield return new WaitUntil(() => _timerinProgress);
        

        if (_currentData.NumEnemytoKill == 0)
        {
            SetIsWin(true);
        }
        else
        {
            SetIsWin(false);
        }
    }

    private void DeleteGuy(GameObject guy)
    {
        _blackHoleEnemies.Remove(guy);
        Destroy(guy);
        _currentData.NumEnemytoKill--;
    }

    public void Update()
    {

        foreach (var guy in _blackHoleEnemies)
        {
            if (_player.PlayerRadius > Vector2.Distance(guy.transform.position, _player.transform.position))
            {
                _whenKillGy.Invoke();
                DeleteGuy(guy);
            }
        }
        
    }
}
