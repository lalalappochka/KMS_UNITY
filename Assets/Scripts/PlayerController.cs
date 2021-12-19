using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool _cursorEnabled = false;
    private FirstPersonController _controller;
    private IInteractable _interactable;
    public IInteractable Interactable
    {
        get => _interactable;
        set
        {
            if (_interactable != value)
            {
                _interactable?.OnInteractStop();
                _interactable = value;
                _interactable?.OnInteractStart();
            }
        }
    }

    private void Start()
    {
        _controller = GetComponent<FirstPersonController>();
    }

    private void FixedUpdate()
    {
        var ray = FocusManager.Instance.CurrentCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if (raycastHit.transform.TryGetComponent(out IInteractable interactable))
            {
                Interactable = interactable;
            }
            else if (raycastHit.transform.root.TryGetComponent(out IInteractable rootInteractable))
            {
                Interactable = rootInteractable;
            }
        }
        else
        {
            Interactable = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UpdateCursorVisible();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Interactable?.OnClicked();
        }

        if (TaskTracker.Instance.TaskId == 2 && Input.GetKeyDown(KeyCode.L))
        {
            TaskTracker.Instance.TaskDone(2);
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

    private void UpdateCursorVisible()
    {
        _cursorEnabled = !_cursorEnabled;
        SetCursorVisible(_cursorEnabled);
    }

    public void SetCursorVisible(bool visible)
    {
        Cursor.visible = visible;
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        _controller.enabled = !visible;
    }
}
