using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InstructionSerialization : MonoBehaviour
{
    private string InstructionsName = "Engine_Instructions.json";
    private string _path;
    public EngineInstructions instructions;


    private void Awake() 
    {

        _path = Application.streamingAssetsPath + "/" + InstructionsName;
        
        if (!File.Exists(_path))
        {
            Debug.LogWarning("Unable to locate instructions! Make sure the path is correct");
            Debug.Log(_path);
            return;
        }

        string jsonString = File.ReadAllText(_path);
        instructions = JsonUtility.FromJson<EngineInstructions>(jsonString);
    }

    public EngineStep GetInstructionDataByID(int id)
    {
        EngineStep[] steps = instructions.Steps;
        for (int i = 0; i < instructions.Steps.Length; i++)
        {
            if (instructions.Steps[i].ObjectID == id)
            {
                return instructions.Steps[i];
            }
        }

        Debug.LogWarning("Instructions with ID: " + id + " not found, please make sure the id is correct");
        return null;
    }
    public EngineStep[] GetSteps()
    {
        return instructions.Steps;
    }

}
