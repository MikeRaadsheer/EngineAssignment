using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePartVisualizer : MonoBehaviour
{
    [SerializeField]
    private InstructionManager _instructionManager;
    [SerializeField]
    private InstructionSerialization _instructionData;

    [SerializeField]
    private Transform[] _engineParts;

    private bool _isTransitioning = false;
    private bool _isHighlighted = false;
    private Material _partMat;
    private Color _partOldCol;
    private Color _newCol;
    private float _colTansition = 0f;

    private string _partPrefix = "NITRO_ENGINE.";

    void Start()
    {
        _instructionManager = FindObjectOfType<InstructionManager>();
        _instructionData = GetComponent<InstructionSerialization>();
        _engineParts = transform.GetComponentsInChildren<Transform>();

        _instructionManager.SelectStep += GetPartID;
    }

    private void GetPartID(Steps step)
    {
        switch (step)
        {
            case Steps.PREVIEW:
                ResetPartMat();
                break;
            case Steps.STEP1:
                HighLightPart(97);
                break;
            case Steps.STEP2:
                HighLightPart(59);
                break;
            case Steps.STEP3:
                HighLightPart(122);
                break;
            case Steps.STEP4:
                HighLightPart(3);
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        if (!_isTransitioning) { return; }

        _colTansition += Time.deltaTime;

        _partMat.color = Color.Lerp(_partOldCol, _newCol, _colTansition);

            if (_colTansition >= 1f)
        {
            _isTransitioning = false;
            _isHighlighted = true;
            _colTansition = 0f;
        }
    }

    public void ResetPartMat()
    {
        if (!_partMat) { return; }

        _partMat.color = _partOldCol;
        _isHighlighted = false;
    }

    public void HighLightPart(int ObjectID)
    {
        ResetPartMat();

        string _partName = _partPrefix + ObjectID.ToString("000");
        Transform part = null;

        try
        {
            for (int i = 0; i < _engineParts.Length; i++)
            {
                if(_engineParts[i].name == _partName)
                {
                    part = _engineParts[i];
                    break;
                }
            }
        }
        catch
        {
            Debug.LogError("Unable to select needed requested part.");
            return;
        }

        _partMat = part.GetComponent<Renderer>().material;
        _partOldCol = _partMat.color;

        EngineStep step = _instructionData.GetInstructionDataByID(ObjectID);
        HighLightColors cols = step.HighLightColor;
        _newCol = new Color(cols.r, cols.g, cols.b, cols.a);
        _isTransitioning = true;
    }
}
