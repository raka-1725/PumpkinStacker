using System;
using UnityEngine;

public enum PumpkinState
{
    Stage1 = 1,
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
    public PumpkinState state { get; private set; }
    [SerializeField] private int currentstage = 0;
    private bool bIsMerging = false;
    private Vector3 Spritescale = new Vector3(0.1f, 0.1f, 0.1f);

    private void Awake()
    {
        UpdatePumpkinState(1);
    }

    public void UpdatePumpkinState(int stage)
    {
        if (stage < 1 || stage > 12) return;
        state = (PumpkinState)stage;
        float scaleindex = stage * 0.1f;
        transform.localScale = new Vector3(scaleindex, scaleindex, scaleindex);
    }
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (bIsMerging) return;
        if (other.CompareTag("Pumpkin"))
        {
            SPumpkin otherPumpkin = other.GetComponent<SPumpkin>();
            if (otherPumpkin.state == state)
            {
                int nextStage = (int)state + 1;
                if (nextStage > 12) return;
                if (otherPumpkin.bIsMerging) return;
                bIsMerging = true;
                otherPumpkin.bIsMerging = true;
                UpdatePumpkinState(nextStage);
                Debug.Log("pumpkin upgraded");

                Destroy(other.gameObject);
                bIsMerging = false;
            }

        }
    }
}
