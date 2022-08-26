using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float mouseX;
    private float mouseY;
    public float sensilivityMouse = 200f;
    public Transform player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensilivityMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensilivityMouse * Time.deltaTime;

        player.Rotate(mouseX * new Vector3(0, 1, 0));

        transform.Rotate(-mouseY * new Vector3(1, 0, 0));
    }
}
