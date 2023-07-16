using System;
using System.Collections.Generic;
using Level;
using Utils.ProcessTool;

public class ProcessManager
{
    public Dictionary<Type, Process> processes;
    
    public ProcessManager(Core core)
    {
        processes = new Dictionary<Type, Process>();
    }
    
    public void AddProcess<T>(T process) where T : Process
    {
        if (!processes.ContainsKey(typeof(T)))
        {
            processes.Add(typeof(T), process);
        }
    }
    
    public void RemoveAllProcesses()
    {
        foreach (var process in processes.Values)
        {
            process.Stop();
        }
        processes.Clear();
    }
}