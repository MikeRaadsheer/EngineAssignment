using System;

[Serializable]
public class EngineStep
{
    public int ObjectID;
    public string Instruction;
    public HighLightColors HighLightColor;

    public EngineStep(int objID, string instruction)
    {
        ObjectID = objID;
        Instruction = instruction;
    }
}
