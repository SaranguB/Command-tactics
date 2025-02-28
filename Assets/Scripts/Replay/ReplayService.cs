
using System;
using System.Collections.Generic;
using Command.Commands;
using Command.Main;
using UnityEngine.Playables;

namespace Command.Replay
{
    public class ReplayService
    {
        private Stack<ICommand> replayCommandStack;

        public ReplayState replayState { get; private set; }

        public ReplayService() => SetReplayState(ReplayState.DEACTIVE);

        private void SetReplayState(ReplayState stateToSet) => replayState = stateToSet;
     


        public void SetCommandState(Stack<ICommand> commandToSet) =>
            replayCommandStack = new Stack<ICommand>(commandToSet);


        public void ExecuteNext()
        {
            if (replayCommandStack.Count > 0)
            {
                GameService.Instance.ProcessUnitCommand(replayCommandStack.Pop());
            }
        }
    }
    public enum ReplayState
    {
        ACTIVE,
        DEACTIVE
    }
}

