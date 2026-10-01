using UnityEngine;

public enum PumpkinState
{
    Stage1,
    Stage2,
    Stage3,
    Stage4,
    Stage5,
    Stage6,
    Stage7,
    Stage8,
    Stage9,
    Stage10,
    Stage11,
    Stage12,
}

public class SPumpkin : MonoBehaviour
{
    private PumpkinState state = PumpkinState.Stage1;
    private Vector3 Spritescale = new Vector3(0.1f, 0.1f, 0.1f);
    
    public void UpdatePumpkinState(int stage)
    {
        if (stage < 1 || stage > 12) return;
        state = (PumpkinState)(stage - 1);
        float scaleindex = stage * 0.1f;
        Spritescale = new Vector3(scaleindex, scaleindex, scaleindex);

    }
}
