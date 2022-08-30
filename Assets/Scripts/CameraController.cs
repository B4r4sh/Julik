using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _mouseX;
    private float _mouseY;
    private float _sensilivityMouse = 200f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _sensilivityMouse * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _sensilivityMouse * Time.deltaTime;

        _player.Rotate(_mouseX * new Vector3(0, 1, 0));

        transform.Rotate(-_mouseY * new Vector3(1, 0, 0));
    }
}
