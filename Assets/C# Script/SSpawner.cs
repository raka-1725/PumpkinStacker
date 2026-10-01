using System.Collections;
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
            MovePumpkin(transform);
        }
        else if(transform.position.x < -5)
        {
            inputValue = 0;
            transform.position = new Vector3(-5, transform.position.y, transform.position.z);
            MovePumpkin(transform);
        }
        else
        {
            transform.position += Vector3.right * (inputValue * Time.deltaTime * 7f);
            MovePumpkin(transform);
        }
        //Debug.Log($"input : " + inputValue);
    }

    private void Start()
    {
        SpawnPumpkin();
    }

    public void SpawnPumpkin()
    {
        SpawnedPumpkin = Instantiate(PumpkinPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = SpawnedPumpkin.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void MovePumpkin(Transform spawnerTransform)
    {
        if(!SpawnedPumpkin) return;
        SpawnedPumpkin.transform.position = spawnerTransform.position;
        SpawnedPumpkin.transform.rotation = spawnerTransform.rotation;
    }

    public void DropPumpkin()
    {
        if(!SpawnedPumpkin) return;
        Rigidbody2D rb = SpawnedPumpkin.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        
        SpawnedPumpkin = null;
        
        StartCoroutine(SpawnPumpkinDelayed(0.7f));
    }
    private IEnumerator SpawnPumpkinDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);

        SpawnPumpkin();
    }
}
