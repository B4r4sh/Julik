using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictedAreaControl : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private bool _isTargetLocatedInZone;

    public bool IsTargetLocatedInZone => _isTargetLocatedInZone;

    public bool IsVisable()
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(GetComponent<Camera>());
        var point = _target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                 return false;
            }
        }

        return true;
    }

    public void Update()
    {
        if (IsVisable())
        {
            _isTargetLocatedInZone = true;
        }
        else
        {
            _isTargetLocatedInZone = false;
        }
    }
}
