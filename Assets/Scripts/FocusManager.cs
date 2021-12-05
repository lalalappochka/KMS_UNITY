using System;
using UnityEngine;

public class FocusManager : MonoBehaviour
{
    public static FocusManager Instance { get; private set; }
    public static Action<ItemInfo> OnPartChanged;

    [SerializeField] private FirstPersonController _fpsController;
    [SerializeField] private PlayerController _controller;
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] private Camera _targetCamera;

    private ItemInfo _currentPart;
    private Camera _startCamera;

    public Camera CurrentCamera { get; private set; }
    
    private void Awake()
    {
        Instance = this;
        _startCamera = Camera.main;
        CurrentCamera = _startCamera;
    }

    public void SetCurrentPart(ItemInfo part, bool invokeEvent)
    {
        if (_currentPart == part)
        {
            StopFocus();
            _currentPart = null;
            return;
        }

        if (invokeEvent)
        {
            OnPartChanged?.Invoke(_currentPart);
        }

        _currentPart = part;
        StartFocus(_currentPart.transform.position);
    }

    private void StartFocus(Vector3 pos)
    {
        CurrentCamera = _targetCamera;

        _controller.SetCursorVisible(true);
        _fpsController.enabled = false;
        _fpsCamera.gameObject.SetActive(false);

        _targetCamera.transform.position = pos + Vector3.up - Vector3.right;
        _targetCamera.transform.LookAt(pos);
        _targetCamera.gameObject.SetActive(true);
    }

    private void StopFocus()
    {
        CurrentCamera = _startCamera;
        _controller.SetCursorVisible(false);
        _fpsController.enabled = true;
        _targetCamera.gameObject.SetActive(false);
        _fpsCamera.gameObject.SetActive(true);
    }
}