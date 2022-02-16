using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InstructionManager : MonoBehaviour
{
    private Steps _currentStep = 0;


    public Action<Steps> SelectStep;

    public void NextStep()
    {
        if(_currentStep >= Steps.STEP4)
        {
            _currentStep = Steps.PREVIEW;
        }
        else
        {
            _currentStep++;
        }

        SetStep();
    }
    public void PrevStep()
    {
        if (_currentStep <= Steps.PREVIEW)
        {
            _currentStep = Steps.STEP4;
        }
        else
        {
            _currentStep--;
        }
        
        SetStep();
    }

    private void SetStep()
    {
        if(SelectStep != null)
        {
            SelectStep(_currentStep);
        }
    }
}
