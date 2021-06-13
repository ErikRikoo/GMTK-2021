using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTarget : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if(_start && _end)
        {
            _lineRenderer.SetPosition(0, _start.position);
            _lineRenderer.SetPosition(1, _end.position);
        }
    }

    public void SetTargets(Transform start, Transform end)
    {
        _start = start;
        _end = end;
    }

    public void RemoveTargets()
    {
        _start = null;
        _end = null;
    }
}
