using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStepMovement : MonoBehaviour
{
    private InstructionManager _instructionManager;

    [SerializeField]
    private Vector3[] _positions;
    [SerializeField]
    private Vector3[] _rotations;
    [SerializeField]

    private Steps _currentStep = 0;
    private bool _isTransitioning = false;
    private float _posRotTransition = 0f;
    void Start()
    {
        _instructionManager = FindObjectOfType<InstructionManager>();
        _instructionManager.SelectStep += SetPos;

        transform.position = _positions[((int)Steps.PREVIEW)];
        transform.rotation = Quaternion.Euler(_rotations[((int)Steps.PREVIEW)]);
    }

    private void FixedUpdate()
    {
        if (!_isTransitioning) { return; }

        _posRotTransition += Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, _positions[((int)_currentStep)], _posRotTransition);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rotations[((int)_currentStep)]), _posRotTransition);

        if (_posRotTransition >= 1f)
        {
            _isTransitioning = false;
            _posRotTransition = 0f;
        }
    }

    private void SetPos(Steps step)
    {
        _currentStep = step;

        _isTransitioning = true;
    }
}
