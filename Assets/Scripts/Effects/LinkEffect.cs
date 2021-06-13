using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class LinkEffect : MonoBehaviour
{
    [SerializeField] private GameObjectValueList _crowd;
    [SerializeField] private SphereCollider _areaCollider;
    [SerializeField] private LineRenderer _linePrefab;

    private List<GameObject> _crowdInRange = new List<GameObject>();

    private Dictionary<GameObject, LineRenderer> _lines = new Dictionary<GameObject, LineRenderer>();

    private void Update()
    {
        UpdateList();
        DrawLines();
    }

    private void UpdateList()
    {
        _crowdInRange.Clear();

        foreach (GameObject entity in _crowd)
        {
            float distance = Vector3.Distance(transform.position, entity.transform.position);
            if (distance <= _areaCollider.radius)
            {
                _crowdInRange.Add(entity);
            }
            else
            {
                if (_lines.ContainsKey(entity))
                {
                    if(_lines.ContainsKey(entity))
                    {
                        Destroy(_lines[entity].gameObject);
                    }

                    _lines.Remove(entity);
                }
            }
        }
    }

    private void DrawLines()
    {
        foreach(GameObject entity in _crowdInRange)
        {
            if(!_lines.ContainsKey(entity.gameObject))
            {
                GameObject newLineRenderer = Instantiate(_linePrefab.gameObject, transform.position, _linePrefab.transform.rotation);
                newLineRenderer.GetComponent<LineRendererTarget>().SetTargets(transform, entity.transform);

                _lines.Add(entity, newLineRenderer.GetComponent<LineRenderer>());
            }
        }
    }
}
