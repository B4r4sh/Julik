using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource _stepAudio;
    [SerializeField] private float _speed;
    [SerializeField] private float _stepTimer;

    private CharacterController _charControll;  
    private bool _isStop;
    private Vector3 _move;
    private float _positionX;
    private float _positionZ; 

    private void Start()
    {
        _charControll = GetComponent<CharacterController>();
    }
   
    private void Update()
    {
        _positionX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        _positionZ = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        _move = new Vector3(_positionX, -0, _positionZ);
        _move = Vector3.ClampMagnitude(_move, _speed);
        _move = transform.TransformDirection(_move);

        _charControll.Move(_move);

        // звук шагов
        if (_positionX != 0 || _positionZ != 0)
        {
            if (!_isStop)
            {
                StartCoroutine(playSound());
            }
        }
    }

    private IEnumerator playSound()
    {
        _isStop = true;

        _stepAudio.PlayOneShot(_stepAudio.clip);
        yield return new WaitForSeconds(_stepTimer);

        _isStop = false;
    }
}
