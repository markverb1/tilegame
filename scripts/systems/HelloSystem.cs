using System;

namespace TileSharp;

public partial class HelloSystem : EcsSystem
{
    // Jank required for the Godot Engine
    public HelloSystem()
    {
    }

    public HelloSystem(EcsEntity entity, bool paused = false)
    {
    }

    public override Type[] RequiredComponents { get; } = [typeof(HelloComponent)];
    public override Type[] RequiredSystems { get; } = [];

    protected override void _ProcessSystem(double delta)
    {
        throw new NotImplementedException();
    }

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }
}