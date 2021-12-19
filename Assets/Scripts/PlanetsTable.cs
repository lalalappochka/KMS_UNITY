using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetsTable : MonoBehaviour
{
    [SerializeField] private Text _text;

    private List<string> _planets = new List<string>();

    public static PlanetsTable Inst { get; private set; }

    private void Awake()
    {
        Inst = this;
    }

    public void SawPlanet(string planetName)
    {
        if (_planets.Contains(planetName)) return;
        _planets.Add(planetName);
        _text.text = string.Join(", ", _planets.ToArray());
    }
}
