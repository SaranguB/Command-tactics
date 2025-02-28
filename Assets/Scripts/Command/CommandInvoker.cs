using Command.Main;
using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;

namespace Command.Commands
{
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

        public void Undo()
        {
            if(!RegisterEmpty() && CommandBelongsToActivePlayer())
            commandRegistery.Pop().Undo();
        }

        private bool RegisterEmpty() => commandRegistery.Count == 0;

        private bool CommandBelongsToActivePlayer()
        {
          return (commandRegistery.Peek() as UnitCommand).commandData.ActorPlayerID ==
                GameService.Instance.PlayerService.ActivePlayerID;
        }
    }
}

