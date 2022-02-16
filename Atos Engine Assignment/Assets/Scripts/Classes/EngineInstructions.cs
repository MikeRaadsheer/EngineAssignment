using System;

[Serializable]
public class EngineInstructions
{
    public string InstructionTitle;
    public EngineStep[] Steps;

    public EngineInstructions(string title, EngineStep[] steps)
    {
        InstructionTitle = title;
        Steps = steps;
    }
}