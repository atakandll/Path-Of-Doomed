using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInputNew : MonoBehaviour // responsible for getting ınput from player
{
    private Camera mainCamera;

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
    }

    private void GetMovementInput()
    {
        // burada hareketi için eventi çağırıyourz. ve vector2 döndürdüğü için event böyle yaptık.
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void GetPointerInput()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = mainCamera.nearClipPlane;
        var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        OnPointerPositionChange?.Invoke(mouseInWorldSpace);
    }

}
