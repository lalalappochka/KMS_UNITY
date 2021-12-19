using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField] private float _changeSpeed = 0.5f;
    [SerializeField] private PostProcessVolume _volume;
    [SerializeField] private Transform _switch;

    private DepthOfField _depth;
    private float _currentDepth;

    private void Awake()
    {
        _volume.profile.TryGetSettings(out _depth);

        if (_depth != null)
        {
            _currentDepth = _depth.focusDistance.value;
        }
    }

    private void Update()
    {
        if (_depth == null) return;

        float delta = Input.GetKey(KeyCode.E) ? 1f : (Input.GetKey(KeyCode.Q) ? -1f : 0f);
        if (!Mathf.Approximately(delta, 0f))
        {
            TaskTracker.Instance.TaskDone(3);
            _currentDepth = Mathf.Clamp(_currentDepth + delta * Time.deltaTime * _changeSpeed, .1f, 3f);
            _depth.focusDistance.value = _currentDepth;
            if (_currentDepth > .1f && _currentDepth < 3f)
            {
                _switch.Rotate(Vector3.forward * delta);
            }
        }
    }
}
