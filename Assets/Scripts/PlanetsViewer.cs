using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetsViewer : MonoBehaviour
{
    private bool _cursorEnabled = false;
    private Planet _planet;

    public Planet CurrentPlanet
    {
        get => _planet;
        private set
        {
            if (_planet != value)
            {
                _planet?.OnInteractStop();
                _planet = value;
                _planet?.OnInteractStart();

                if (_planet != null)
                {
                    PlanetsTable.Inst.SawPlanet(_planet.PlanetName);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
        if (Physics.Raycast(ray, out RaycastHit raycastHit) && raycastHit.transform.TryGetComponent(out Planet planet))
        {
            CurrentPlanet = planet;
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
            CurrentPlanet?.OnClicked();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(0);
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
    }
}
