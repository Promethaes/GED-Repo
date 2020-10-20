using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : MonoBehaviour
{
    bool executed = false;

    public CommandManager manager;

    private void Awake()
    {
        manager = GameObject.Find("CommandManager").GetComponent<CommandManager>();
    }

    //pass in false to stop undone list from being cleared
    public void TrackAndExecute(bool clearUndoneList = true)
    {
        execute();
        manager.executionOrder.Add(this);
        manager.commandIndex++;

        if (clearUndoneList)
            manager.undoneCommands.Clear();//might need to clean this up later
    }

    public void TrackAndUndo()
    {
        undo();
    }

    protected abstract void execute();
    protected abstract void undo();

}
