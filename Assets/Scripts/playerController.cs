using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] public float _speed;
    private CharacterController _charControll;
    [SerializeField] public AudioSource _source;
    [SerializeField] public float _stepTimer;
    private bool isStop;
    private Vector3 move;
    float positionX;
    float positionZ; 

    void Start()
    {
        _charControll = GetComponent<CharacterController>();
    }
   
    void Update()
    {
        positionX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        positionZ = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        move = new Vector3(positionX, -0, positionZ);
        move = Vector3.ClampMagnitude(move, _speed);
        move = transform.TransformDirection(move);

        _charControll.Move(move);

        // звук шагов
        if (positionX != 0 || positionZ != 0)
        {
            if (!isStop)
            {
                StartCoroutine(playSound());
            }
        }
    }

    IEnumerator playSound()
    {
        isStop = true;

        _source.PlayOneShot(_source.clip);
        yield return new WaitForSeconds(_stepTimer);

        isStop = false;
    }
}
