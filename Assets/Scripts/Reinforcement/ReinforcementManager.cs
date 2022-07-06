using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReinforcementManager : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private Transform[] _locations;

    [SerializeField]
    private GameObject[] _reinforcementPrefabs;

    [SerializeField]
    private float _sendingTimeCycle;

    private float _lastSendTime = 0;


    private void OnValidate()
    {
        GameObject placeGroup = GameObject.FindGameObjectWithTag("Reinforcements");
        _locations = placeGroup.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if(Time.time - _lastSendTime > _sendingTimeCycle)
        {
            float delayTime = Random.Range(1f, 2f);
            Invoke("SendNewReinforcement", delayTime);
            _lastSendTime = Time.time + delayTime;
        }
    }

    private void SendNewReinforcement()
    {
        Transform location = _locations[Random.Range(0, _locations.Length)];
        GameObject item = _reinforcementPrefabs[Random.Range(0, _reinforcementPrefabs.Length)];
        Instantiate(item, location.position, Quaternion.identity);
    }
    
}
