using Command.Main;
using System.Collections.Generic;


namespace Command.Commands
{
    public class CommandInvoker
    {

        public CommandInvoker()
        {
            //UnityEngine.Debug.Log("hi");
            SubscribeToEvents();
        }

        public void SubscribeToEvents()
        {
            UnityEngine.Debug.Log("Added");

            GameService.Instance.EventService.OnReplayButtonClicked.AddListener(SetReplayStack);
        }

        public void SetReplayStack()
        {
            UnityEngine.Debug.Log("hi");
            GameService.Instance.replayService.SetCommandState(commandRegistery);
            commandRegistery.Clear();
        }

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
            if (!RegisterEmpty() && CommandBelongsToActivePlayer())
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

