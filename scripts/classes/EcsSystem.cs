using System;
using Godot;

namespace TileSharp;

[GlobalClass]
public abstract partial class EcsSystem : Node
{
    protected bool Paused = false;
    public abstract Type[] RequiredComponents { get; }
    public abstract Type[] RequiredSystems { get; }

    protected abstract void _ProcessSystem(double delta);

    public override void _Process(double delta)
    {
        if (Paused) return;
        _ProcessSystem(delta);
    }
}