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
    private float _minAudioVolume;
    private Coroutine _signalOn;
    private Coroutine _signalOff;

    private void Start()
    {
        _animator = _light.GetComponent<Animator>();
        _animatorHash = Animator.StringToHash(name: "enemyIn");
        _minAudioVolume = 0f;
    }

    public void TurnOnSignalCorutine()
    {
        if (_signalOff != null)
        {
            StopCoroutine(_signalOff);
        }

        _signalOn = StartCoroutine(TurnOnSignal());
    }

    public void TurnOffSignalCorutine()
    {
        if (_signalOn != null)
        {
            StopCoroutine(_signalOn);
        }

        _signalOff = StartCoroutine(TurnOffSignal());
    }

    private IEnumerator TurnOnSignal()
    {
        _animator.SetBool(_animatorHash, true);

        while (_audioSignal.volume < _maxAudioVolume)
        {
            _audioSignal.volume = Mathf.MoveTowards(_audioSignal.volume, _maxAudioVolume, _volumeChangeSpeed*Time.deltaTime);
            _animator.speed = Mathf.MoveTowards(_animator.speed, _maxColorAnimationSpeed, _colorAnimationChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator TurnOffSignal()
    {
        _animator.SetBool(_animatorHash, false);

        while (_audioSignal.volume > _minAudioVolume)
        {
            _audioSignal.volume = Mathf.MoveTowards(_audioSignal.volume, _minAudioVolume, _volumeChangeSpeed * Time.deltaTime);
            _animator.speed = Mathf.MoveTowards(_animator.speed, 0f, _colorAnimationChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
