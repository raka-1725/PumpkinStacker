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
    [SerializeField] private int currentstage = 1;
    [SerializeField] private bool bIsMerging = false;
    private Vector3 Spritescale = new Vector3(0.1f, 0.1f, 0.1f);
    

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            transform.position,
            0.5f
        );

        foreach (Collider2D other in colliders)
        {
            if (other.gameObject == gameObject)
                continue;

            if (other.CompareTag("Pumpkin"))
            {
                CheckMerge(other);
                return;
            }
        }
    }

    public void UpdatePumpkinState(int stage)
    {
        if (stage < 1 || stage > 12) return;

        currentstage = stage;
        state = (PumpkinState)stage;
        float scaleIndex = stage * 0.1f;
        transform.localScale = new Vector3(scaleIndex, scaleIndex, scaleIndex);
        GetComponent<SpriteRenderer>().sprite =
            SGameInstance.Instance.GetPumpkinSprite(stage - 1);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckMerge(other);
    }

    private void CheckMerge(Collider2D other)
    {
        if (bIsMerging) return;

        if (other.CompareTag("Pumpkin"))
        {
            SPumpkin otherPumpkin = other.GetComponent<SPumpkin>();
            if (otherPumpkin.bIsMerging) return;
            if (otherPumpkin.state == state)
            {
                int nextStage = (int)state + 1;
                if (nextStage > 12)
                {
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    return;
                }
                bIsMerging = true;
                otherPumpkin.bIsMerging = true;

                UpdatePumpkinState(nextStage);

                Destroy(other.gameObject);
                bIsMerging = false;
            }
        }
    }
}
