using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    [SerializeField] private Transform[] _points;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        SetUpLine(_points);
    }

    private void Update()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            _lineRenderer.SetPosition(i, _points[i].position);
        }
    }

    public void SetUpLine(Transform[] points)
    {
        _lineRenderer.positionCount = points.Length;
        this._points = points;
    }
}
