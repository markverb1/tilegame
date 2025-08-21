using System;
using Godot;

namespace TileSharp;

[GlobalClass]
public partial class TileBasedSystem : EcsSystem
{
    protected TileBasedComponent _tileBasedComponent;
    public override Type[] RequiredComponents { get; } = [typeof(TileBasedComponent)];
    public override Type[] RequiredSystems { get; } = [];
    public override PackedScene Scene { get; } = GD.Load<PackedScene>("uid://bp53jpqam642q");

    protected override bool _ReadySystem()
    {
        _tileBasedComponent = myEntity.GetComponent<TileBasedComponent>(true);
        return true;
    }

    protected override void _ProcessSystem(double delta)
    {
    }
}