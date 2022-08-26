using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _speed;
    [SerializeField] GameObject _deadPanel;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<playerController>(out playerController player))
        {
            _deadPanel.SetActive(true);
        }
    }
}
