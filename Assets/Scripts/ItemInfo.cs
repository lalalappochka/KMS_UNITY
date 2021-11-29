using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] private string _itemName;

    public string ItemName { get => _itemName; private set => _itemName = value; }
}
