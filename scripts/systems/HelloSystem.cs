using System;
using Godot;

namespace TileSharp;

[GlobalClass]
public partial class HelloSystem : EcsSystem
{
    private HelloComponent _helloComponent;
    public override Type[] RequiredComponents { get; } = [typeof(HelloComponent)];
    public override Type[] RequiredSystems { get; } = [];
    public override PackedScene Scene { get; } = GD.Load<PackedScene>("uid://bp53jpqam642q");

    protected override bool _ReadySystem()
    {
        _helloComponent = myEntity.GetComponent<HelloComponent>(true);
        for (var I = 0;
             I < _helloComponent.TimesToPrint;
             ++I)
            GD.Print(_helloComponent.ThingToPrint);
        return true;
    }

    protected override void _ProcessSystem(double delta)
    {
    }
}