using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemsDropdown : MonoBehaviour
{
    private Dropdown _dropdown;
    private void Start()
    {
        _dropdown = GetComponent<Dropdown>();

        _dropdown.onValueChanged.AddListener(OnValueChangedHandler);
        FocusManager.OnPartChanged += OnPartChangedHandler;

        ItemsManager.Instance.Parts.ForEach(item => _dropdown.options.Add(new Dropdown.OptionData(item.ItemName)));
    }

    private void OnPartChangedHandler(IInteractable obj)
    {
        if (obj == null)
        {
            _dropdown.value = 0;
            return;
        }

        var item = obj as ItemInfo;

        for (int i = 0; i < _dropdown.options.Count; i++)
        {
            if (_dropdown.options[i].text == item.ItemName)
            {
                _dropdown.value = i;
                break;
            }
        }
    }

    private void OnValueChangedHandler(int idx)
    {
        string name = _dropdown.options[idx].text;

        foreach (var part in ItemsManager.Instance.Parts)
        {
            if (part.ItemName == name)
            {
                part.SetThisToCurrent(false);
                break;
            }
        }
    }
}
