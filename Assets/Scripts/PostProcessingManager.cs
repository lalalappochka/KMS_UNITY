using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField] private float _changeSpeed = 0.5f;
    [SerializeField] private PostProcessVolume _volume;

    private DepthOfField _depth;
    private float _currentDepth;

    private void Awake()
    {
        _volume.profile.TryGetSettings(out _depth);

        _currentDepth = _depth.focusDistance.value;
    }

    private void Update()
    {
        float delta = Input.GetKey(KeyCode.E) ? 1f : (Input.GetKey(KeyCode.Q) ? -1f : 0f);
        if (!Mathf.Approximately(delta, 0f))
        {
            TaskTracker.Instance.TaskDone(3);
            _currentDepth = Mathf.Clamp(_currentDepth + delta * Time.deltaTime * _changeSpeed, .1f, 3f);
            _depth.focusDistance.value = _currentDepth;
            Debug.Log(_currentDepth);
        }
    }
}
