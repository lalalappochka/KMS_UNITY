using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TaskText : MonoBehaviour
{
    private Text _text;
    private void Awake()
    {
        _text = GetComponent<Text>();

        TaskTracker.TaskChanged += TaskTracker_TaskChanged;
    }

    private void Start()
    {
        TaskTracker_TaskChanged(TaskTracker.Instance.TaskText);
    }

    private void OnDestroy()
    {
        TaskTracker.TaskChanged -= TaskTracker_TaskChanged;
    }

    private void TaskTracker_TaskChanged(string text)
    {
        _text.text = text;
    }

}