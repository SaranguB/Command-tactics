
using Command.Player;

public abstract class UnitCommand : ICommand
{
    public int actorUnitID;
    public int targetUnitID;
    public int actorPlayerID;
    public int targetPlayerID;

    protected UnitController actorUnit;
    protected UnitController targetUnit;

    public abstract void Execute();

    public abstract bool WillItHitTarget();
}
