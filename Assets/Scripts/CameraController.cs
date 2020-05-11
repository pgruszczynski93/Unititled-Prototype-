using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] Transform _target;
    [SerializeField] Transform _thisTransform;

    Vector3 _offset;

    void Start() {
        _offset = _target.localPosition - _thisTransform.localPosition;
    }

    void LateUpdate() {
        _thisTransform.localPosition = _target.localPosition - _offset;
    }
}
