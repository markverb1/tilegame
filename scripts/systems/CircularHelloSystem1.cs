using System;
using Godot;

namespace TileSharp;

[GlobalClass]
public partial class CircularHelloSystem1 : EcsSystem
{
    private HelloComponent _helloComponent;
    public override Type[] RequiredComponents { get; } = [];
    public override Type[] RequiredSystems { get; } = [typeof(CircularHelloSystem2)];
    public override PackedScene Scene { get; } = GD.Load<PackedScene>("uid://bp53jpqam642q");

    protected override void _ReadySystem()
    {
        GD.Print("Hello First Circle!");
    }

    protected override void _ProcessSystem(double delta)
    {
    }
}