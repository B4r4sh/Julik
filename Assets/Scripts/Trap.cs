using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject _img;
    [SerializeField] private GameObject _Shrek;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMovement > (out PlayerMovement player))
        {
            _img.SetActive(true);
            _Shrek.SetActive(true);
        }
    }
}
