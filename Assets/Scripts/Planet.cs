using UnityEngine;

[RequireComponent(typeof(Outline), typeof(Collider))]
public class Planet : MonoBehaviour, IInteractable
{
    [SerializeField] private string _planetName;
    [SerializeField] private string _planetDesc;

    private Outline _outline;

    public string PlanetName => _planetName;
    public string PlanetDesc => _planetDesc;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }

    public void OnInteractStart()
    {
        _outline.enabled = true;
        PlanetInfoDisplay.Instance.ShowText(PlanetName, PlanetDesc);

        TaskTracker.Instance.TaskDone(4);
    }

    public void OnInteractStop()
    {
        _outline.enabled = false;
    }

    public void OnClicked()
    {
        
    }
}
