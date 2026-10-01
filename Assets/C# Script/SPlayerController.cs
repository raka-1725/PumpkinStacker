using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SPlayerController : MonoBehaviour
{
    private PlayerInputAction inputAction;
    
    [SerializeField] private SSpawner spawner;
    
    private float moveInput;
    
    private void Awake()
    {
        inputAction = new PlayerInputAction();
        inputAction.Player.Horizontal.performed += PerformMovement;
        inputAction.Player.Horizontal.canceled += PerformMovement;
        inputAction.Player.Drop.performed += Drop;
    }
    private void OnEnable() => inputAction.Player.Enable();
    private void OnDisable() => inputAction.Player.Disable();
    private void PerformMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
        spawner.MoveSpawner(moveInput);
       // Debug.Log($"input : " + moveInput);
    }

    private void Update()
    {
        spawner.MoveSpawner(moveInput);
    }

    private void Drop(InputAction.CallbackContext context)
    {
        
    }
}
