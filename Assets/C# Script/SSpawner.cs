using UnityEngine;

public class SSpawner : MonoBehaviour
{
    private PumpkinState state;
    [SerializeField] private GameObject PumpkinPrefab;
    private GameObject SpawnedPumpkin;
    public void MoveSpawner(float inputValue)
    {
        if(transform.position.x > 5)
        {
            inputValue = 0;
            transform.position = new Vector3(5, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -5)
        {
            inputValue = 0;
            transform.position = new Vector3(-5, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position += Vector3.right * (inputValue * Time.deltaTime * 7f);
        }
        //Debug.Log($"input : " + inputValue);
    }
    
    public void SpawnPumpkin()
    {
        SpawnedPumpkin = Instantiate(PumpkinPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = SpawnedPumpkin.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    public void DropPumpkin()
    {
        if(SpawnedPumpkin == null) return;
        Rigidbody2D rb = SpawnedPumpkin.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
    }
}
