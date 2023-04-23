using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput // is getting ınput from the player
{
    private Camera mainCamera;
    private bool fireButton = false;

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; } // fare imleci için prop yapıyoruz.

    [field: SerializeField]
    public UnityEvent OnFireButtonPressed { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonReleased { get; set; }
    private void Awake()
    {
        mainCamera = Camera.main;

    }
    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();

    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (fireButton == false) // sadece bir kez çalışmasını sağlayacak
            {
                fireButton = true;
                OnFireButtonPressed?.Invoke();
            }
        }
        else
        {
            if (fireButton) // sadece bir kez çalışmasını sağlayacak
            {
                fireButton = false;
                OnFireButtonReleased?.Invoke();
            }
        }

    }

    private void GetPointerInput()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = mainCamera.nearClipPlane; // bu iki kod bi hata olmaması için unity doc dan alındı normalde yoktu bunlar garanti olsun diye yaptık.

        var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(mousPos); // we want to rotate player to face the cursor(imleç) of our mouse 
        OnPointerPositionChange?.Invoke(mouseInWorldSpace);
    }

    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))); // ? means if anybody is listening this event. Invoke ile çağırdık

    }
}

