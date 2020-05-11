using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBodyController : MonoBehaviour {
    [SerializeField] float _forceMultiplier;
    [SerializeField] Rigidbody _rigidbody;
    void OnEnable() {
        OrbiterMovementController.OnPushDirectionChanged += HandleOnPushDirectionChanged;
    }


    void OnDisable() {
        OrbiterMovementController.OnPushDirectionChanged -= HandleOnPushDirectionChanged;
    }

    void HandleOnPushDirectionChanged(Vector3 pushVec) {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(_forceMultiplier * pushVec, ForceMode.Impulse);
    }
}
