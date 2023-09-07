using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "MiniGame 5", menuName = "MiniGame/MiniGame 5", order = 1)]
public class TargetController : MinigameController<MinigameBaseData>
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private int _pointCount = 0;
    [SerializeField] private float _radius = 1.0f;
    [SerializeField] private Transform _target;
    private bool _touchTarget;

    protected override void StartMiniGame()
    {
        StartCoroutine(Chrono());
        StartCoroutine(MiniGameCoroutine());
    }

    IEnumerator MiniGameCoroutine()
    {
        yield return new WaitUntil((() => _timerinProgress || _touchTarget));

        if (_touchTarget)
        {
            SetIsWin(true);
        }
        else
        {
            SetIsWin(false);
        }
    }

    private void FixedUpdate()
    {
        _player.transform.position = Vector3.MoveTowards(_player.transform.position, _points[_pointCount].position,
            _currentData.PlayerSpeed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        if (_points != null)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                if (i == _points.Length)
                {
                    Gizmos.DrawLine(_points[i].position, _points[0].position);
                }
                else
                {
                    Gizmos.DrawLine(_points[i].position, _points[i + 1].position);
                }
                Gizmos.DrawSphere(_points[i].position,_radius);
                Gizmos.color = Color.cyan;
            }
        }
    }
}
