using System;

namespace TileSharp;

public partial class HelloSystem : EcsSystem
{
    // Jank required for the Godot Engine

    public override Type[] RequiredComponents { get; } = [typeof(HelloComponent)];
    public override Type[] RequiredSystems { get; } = [];

    protected override void _ReadySystem()
    {
        
    }

    protected override void _ProcessSystem(double delta)
    {
    }
}