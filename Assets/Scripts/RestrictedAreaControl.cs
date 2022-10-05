using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RestrictedAreaControl : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Signalization _signalisation;

    private bool _isTargetLocatedInZone;
    private bool _isSignalOn;

    public bool IsTargetLocatedInZone => _isTargetLocatedInZone;

    private void Start()
    {
        _isSignalOn = false;
    }
    private bool IsVisable()
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

    private void Update()
    {
        if (IsVisable())
        {
            if (_isSignalOn == false)
            {
                _signalisation.TurnOnSignalCorutine();
                _isSignalOn = true;
            }
        }
        else
        {
            if (_isSignalOn == true)
            {
                _signalisation.TurnOffSignalCorutine();
                _isSignalOn = false;
            }
        }
    }
}
