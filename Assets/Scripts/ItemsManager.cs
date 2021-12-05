using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private List<ItemInfo> _parts;
    
    public static ItemsManager Instance { get; private set; }
    public List<ItemInfo> Parts { get => _parts; private set => _parts = value; }

    private void Awake()
    {
        Instance = this;

        var parts = FindObjectsOfType<ItemInfo>();
        Parts = new List<ItemInfo>(parts);
    }
}