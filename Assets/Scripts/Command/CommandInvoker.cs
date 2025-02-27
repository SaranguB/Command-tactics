using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;

public class CommandInvoker
{
    private Stack<ICommand> commandRegistery = new Stack<ICommand>();

    public void ProcessCommand(ICommand commandToProcess)
    {
        ExecuteCommand(commandToProcess);
        RegisterCommand(commandToProcess);
    }

    public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();


    public void RegisterCommand(ICommand commandToRegister) => commandRegistery.Push(commandToRegister);


   
}
