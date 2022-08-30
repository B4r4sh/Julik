using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private float _maxColorAnimationSpeed;
    [SerializeField] private float _colorAnimationChangeSpeed;
    [SerializeField] private AudioSource _audioSignal;
    [SerializeField] private float _maxAudioVolume;
    [SerializeField] private float _volumeChangeSpeed;
    [SerializeField] private Camera _signalizationCamera;

    private Animator _animator;
    private int _animatorHash;
    private float _minColorAnimationSpeed;
    private float _minVolume;
    RestrictedAreaControl _isTargetLocatedInZone;

    private void Start()
    {
        _animator = _light.GetComponent<Animator>();
        _animatorHash = Animator.StringToHash(name: "enemyIn");
        _minColorAnimationSpeed = 1f;
        _minVolume = 0f;
        _isTargetLocatedInZone = _signalizationCamera.GetComponent<RestrictedAreaControl>();
    }

    private void Update()
    {
        if (_isTargetLocatedInZone.IsTargetLocatedInZone == true)
        {
            _animator.SetBool(_animatorHash, true);
            AnimateSignalization(_maxColorAnimationSpeed, _maxAudioVolume ); 
        }
        else
        {
            _animator.SetBool(_animatorHash, false);
            AnimateSignalization(_minColorAnimationSpeed, _minVolume );
        }
    }

    private void AnimateSignalization( float targetColorAnimation, float targetVolume)
    {
        _animator.speed = Mathf.MoveTowards(_animator.speed, targetColorAnimation, _colorAnimationChangeSpeed * Time.deltaTime);
        _audioSignal.volume = Mathf.MoveTowards(_audioSignal.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
    }
}
