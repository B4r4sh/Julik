using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalizationManager : MonoBehaviour
{
    public GameObject _target;
    public Camera _cam;
    public Light _light;
    private Animator _animator;
    [SerializeField] private float _maxColorAnimationSpeed;
    [SerializeField] private float _colorAnimationChangeSpeed;
    [SerializeField] AudioSource _audioSignal;
    [SerializeField] public float _maxAudioVolume;
    [SerializeField] public float _volumeChangeSpeed;
    private float _minColorAnimationSpeed;
    private float _minVolume;

    private bool IsVisable(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }

        return true;
    }

    private void Start()
    {
        _animator = _light.GetComponent<Animator>();
        _minColorAnimationSpeed = 1f;
        _minVolume = 0f;
    }

    private void Update()
    {
        if (IsVisable(_cam, _target))
        {
            _animator.SetBool("enemyIn", true);
            MotionAnimation(_maxColorAnimationSpeed, _maxAudioVolume );
        }
        else
        {
            _animator.SetBool("enemyIn", false);
            MotionAnimation(_minColorAnimationSpeed, _minVolume );
        }
    }

    private void MotionAnimation( float targetColorAnimation, float targetVolume)
    {
        _animator.speed = Mathf.MoveTowards(_animator.speed, targetColorAnimation, _colorAnimationChangeSpeed * Time.deltaTime);
        _audioSignal.volume = Mathf.MoveTowards(_audioSignal.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
    }
}
