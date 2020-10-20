using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CommandManager : MonoBehaviour
{
    public List<Command> commands = new List<Command>();

    public List<Command> executionOrder = new List<Command>();

    public List<Command> undoneCommands = new List<Command>();



    public int commandIndex = 0;
    public void MasterUndo()
    {
        if (commandIndex <= 0)
            return;
        executionOrder[commandIndex - 1].TrackAndUndo();
        undoneCommands.Add(executionOrder[commandIndex - 1]);
        executionOrder.RemoveAt(commandIndex - 1);
        commandIndex--;
        
    }

    public void MasterRedo()
    {
        if (undoneCommands.Count == 0)
            return;

        undoneCommands[undoneCommands.Count - 1].TrackAndExecute(false);
        undoneCommands.RemoveAt(undoneCommands.Count - 1);

    }

    //probably not gonna be used
    public void MasterExecute()
    {
        executionOrder[commandIndex].TrackAndExecute();
        commandIndex++;

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
