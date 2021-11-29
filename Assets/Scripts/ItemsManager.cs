using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public List<ItemInfo> items;
    private void Awake()
    {
        var items = GameObject.FindObjectOfTypeAll<ItemInfo>();
        items = new List<ItemInfo>(items);
    }
}