using UnityEngine;
using UnityEngine.Tilemaps;

public class SGameInstance : MonoBehaviour
{
    public static SGameInstance Instance { get; private set; }

    public int SpawnSizeIndex { get; private  set; }
    //sprite array
    [SerializeField] private Sprite[] pumpkinSprites;
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
}
