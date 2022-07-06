using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveReinforcementHandler : MonoBehaviour
{
    protected AudioSource _receiveSound;

    protected GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _receiveSound = GetComponent<AudioSource>();
    }

    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.gameObject == _player)
        {
            _receiveSound?.Play();
            ApplyReinforcement();
        }
    }

    protected virtual void ApplyReinforcement()
    {

    }
}
