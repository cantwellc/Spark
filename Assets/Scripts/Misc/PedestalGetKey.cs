using UnityEngine;
using UnityEngine.Events;

using System.Collections;
using System;

public class PedestalGetKey : MonoBehaviour {
    public UnityEvent OnKeyFinalPositionReached;

    public float toStageSpeed;
    public Transform stageTarget;

    public float toFinalSpeed;
    public Transform finalTarget;


    private bool _moveToStage;
    private bool _moveToFinal;
    private Transform _key;
    private float _timeToStage;
    private float _toStageStartTime;
    private float _toFinalStartTime;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Key") return;
        _key = other.gameObject.transform;
        _key.transform.SetParent(finalTarget, true);
        CalcTimeToStage();
        MoveKeyToStage();
    }

    private void CalcTimeToStage()
    {
        _timeToStage = Vector3.Distance(_key.position, stageTarget.position);
    }

    void MoveKeyToStage()
    {
        _moveToFinal = false;
        _moveToStage = true;
        _toStageStartTime = Time.time;
    }

    void MoveKeyToFinal()
    {
        _moveToStage = false;
        _moveToFinal = true;
        _toFinalStartTime = Time.time;
    }

    private void StopMoveFinal()
    {
        _moveToFinal = false;
        _moveToStage = false;
        OnKeyFinalPositionReached.Invoke();
    }

    void Update()
    {
        if (_moveToStage)
        {
            var step = toStageSpeed * Time.deltaTime;
            var ratio = (Time.time - _toStageStartTime) / _timeToStage;
            _key.position = Vector3.MoveTowards(_key.position, stageTarget.position, step);
            _key.rotation = Quaternion.Lerp(_key.rotation, stageTarget.rotation, ratio);
            if (_key.position == stageTarget.position) MoveKeyToFinal();
        }
        else if (_moveToFinal)
        {
            var step = toFinalSpeed * Time.deltaTime;
            _key.position = Vector3.MoveTowards(_key.position, finalTarget.position, step);
//            _key.rotation = Quaternion.RotateTowards(_key.rotation, finalTarget.rotation, step);
            if (_key.position == finalTarget.position) StopMoveFinal();
        }
        
    }

}
