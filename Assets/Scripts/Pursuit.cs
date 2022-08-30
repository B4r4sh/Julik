using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _deadPanel;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _deadPanel.SetActive(true);
        }
    }
}
