using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskTracker : MonoBehaviour
{
    public static TaskTracker Instance { get; private set; }
    public static event Action<string> TaskChanged;

    [SerializeField] private List<TaskInfo> _tasks;

    private TaskInfo _task;

    public TaskInfo Task
    {
        get => _task;
        private set
        {
            _task = value;
            TaskChanged?.Invoke(TaskText);
        }
    }

    public int TaskId { get; private set; } = 0;
    public string TaskText => $"Текущее задание: <color=#ff0000ff>{_task.taskText}</color>";

    private void Awake()
    {
        Instance = this;

        Task = _tasks[TaskId];

        DontDestroyOnLoad(this);
    }

    public void TaskDone(int id)
    {
        if (TaskId != id) return;
        ++id;
        if (_tasks.Count < id + 1) return;
        var nextTask = _tasks[id];
        if (nextTask != null)
        {
            TaskId = id;
            Task = nextTask;
        }
    }
}