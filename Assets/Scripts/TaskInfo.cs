using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "TaskInfo", menuName = "ScriptableObjects/TaskInfo")]
public class TaskInfo : ScriptableObject
{
    public string taskText;
}