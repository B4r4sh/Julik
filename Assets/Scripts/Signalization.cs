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
    private Coroutine _signalOn;
    private Coroutine _signalOff;

    private void Start()
    {
        _animator = _light.GetComponent<Animator>();
        _animatorHash = Animator.StringToHash(name: "enemyIn");
    }

    public void TurnOnSignalCorutine()
    {
        _animator.SetBool(_animatorHash, true);

        if (_signalOff != null)
        {
            StopCoroutine(_signalOff);
        }

        _signalOn = StartCoroutine(ControlSignal(_maxAudioVolume, _maxColorAnimationSpeed));
    }

    public void TurnOffSignalCorutine()
    {
        _animator.SetBool(_animatorHash, false);

        if (_signalOn != null)
        {
            StopCoroutine(_signalOn);
        }

        _signalOff = StartCoroutine(ControlSignal(0f, 0f));
    }

    private IEnumerator ControlSignal(float targetAudioVolume, float targetColorAnimationSpeed)
    {
        while (_audioSignal.volume < _maxAudioVolume)
        {
            _audioSignal.volume = Mathf.MoveTowards(_audioSignal.volume, targetAudioVolume, _volumeChangeSpeed * Time.deltaTime);
            _animator.speed = Mathf.MoveTowards(_animator.speed, targetColorAnimationSpeed, _colorAnimationChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
