using System;
using UnityEngine;

public class OrbiterMovementController : MonoBehaviour {

    public static event Action<Vector3> OnPushDirectionChanged; 
    
    [SerializeField] float _orbiterInitialAngle;
    [SerializeField] float _rotationSpeed;
    [SerializeField] Transform _mainBody;
    [SerializeField] Transform _thisTransform;

    float _distance;
    float _currentAngle;
    float _dt;

    Vector3 _mainBodyPos;
    Vector3 _orbiterPos;
    Vector3 _pushDirection;
    
    void Start() {
        _currentAngle = _orbiterInitialAngle;
        _orbiterPos = _thisTransform.position;
        _mainBodyPos = _mainBody.position;
        _distance = Vector3.Distance(_orbiterPos, _mainBodyPos);
    }

    void Update() {
        UpdateOrbiterPosition();
        TryToBroadcastPushDirectionChanged();
    }

    void UpdateOrbiterPosition() {
        _dt = Time.deltaTime;
        _currentAngle += _dt * _rotationSpeed;
        _orbiterPos = _thisTransform.position;
        _mainBodyPos = _mainBody.position;
        _distance = Vector3.Distance(_orbiterPos, _mainBodyPos);
        float newPosX = _distance * Mathf.Cos(_currentAngle);
        float newPosY = _distance * Mathf.Sin(_currentAngle);
        _orbiterPos = new Vector3(newPosX+_mainBodyPos.x, newPosY+_mainBodyPos.y, 0);
        _thisTransform.position = _orbiterPos;
    } 

    void TryToBroadcastPushDirectionChanged() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            var pushDir = (_mainBodyPos - _orbiterPos).normalized;
            OnPushDirectionChanged?.Invoke(pushDir);
        }
    }
    
}
