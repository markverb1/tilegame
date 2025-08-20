using System;
using Godot;

namespace TileSharp;

[GlobalClass]
public partial class CircularHelloSystem1 : EcsSystem
{
    private HelloComponent _helloComponent;
    public override Type[] RequiredComponents { get; } = [];
    public override Type[] RequiredSystems { get; } = [typeof(CircularHelloSystem1)];
    public override PackedScene Scene { get; } = GD.Load<PackedScene>("uid://bp53jpqam642q");

    protected override void _ReadySystem()
    {
        _helloComponent = myEntity.GetComponent<HelloComponent>(true);
        for (var I = 0;
             I < _helloComponent.TimesToPrint;
             ++I)
            GD.Print(_helloComponent.ThingToPrint);
    }

    protected override void _ProcessSystem(double delta)
    {
    }
}