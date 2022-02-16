using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionText : MonoBehaviour
{
    private InstructionManager _instructionManager;
    private InstructionSerialization _instructionData;

    private EngineStep[] _steps;

    private TMP_Text _txt;

    void Start()
    {
        _instructionManager = FindObjectOfType<InstructionManager>();
        _instructionData = FindObjectOfType<InstructionSerialization>();

        _txt = GetComponent<TMP_Text>();

        _steps = _instructionData.GetSteps();

        _instructionManager.SelectStep += SetText;
        SetText(Steps.PREVIEW);
    }

    private void SetText(Steps step)
    {
        string prefix = "step " + ((int)step) + ": ";

        if(step == Steps.PREVIEW)
        {
            _txt.text = "Nitro Engine Instructions by: Atos";
        }
        else
        {
            _txt.text = prefix + _steps[((int)step)-1].Instruction;
        }
    }
}
