using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfoDisplay : MonoBehaviour
{
    public static PlanetInfoDisplay Instance { get; private set; }

    [SerializeField] private Text _info;
    [SerializeField] private Text _name;
    [SerializeField] private CanvasGroup _group;

    private Coroutine _canvasAnim;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowText(string name, string info)
    {
        _info.text = info;
        _name.text = name;

        if (_canvasAnim != null)
        {
            StopCoroutine(_canvasAnim);
        }
        _canvasAnim = StartCoroutine(FadeCoroutine(0.5f));
    }

    private IEnumerator FadeCoroutine(float duration)
    {
        float startTime = Time.time;

        _group.alpha = 0f;
        while (true)
        {
            float alpha = Mathf.Clamp01((Time.time - startTime) / duration);

            _group.alpha = alpha;

            if (alpha >= 1f) break;
            yield return null;
        }
    }
}
