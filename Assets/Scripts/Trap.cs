using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] GameObject _img;
    [SerializeField] GameObject _Shrek;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<playerController>(out playerController player))
        {
            _img.SetActive(true);
            _Shrek.SetActive(true);
        }
    }
}
