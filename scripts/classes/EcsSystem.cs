using System;
using Godot;

namespace TileSharp;

[GlobalClass]
[Icon("uid://6c6y86sigj40")]
public abstract partial class EcsSystem : Node
{
    public EcsEntity myEntity;
    public bool Paused = false;

    protected EcsSystem()
    {
    }

    public EcsSystem(EcsEntity entity, bool paused = false)
    {
        myEntity = entity;
        Paused = paused;
    }

    public abstract Type[] RequiredComponents { get; }
    public abstract Type[] RequiredSystems { get; }

    protected abstract void _ReadySystem();
    protected abstract void _ProcessSystem(double delta);

    public void SetPaused(bool pause)
    {
        Paused = pause;
    }
    public sealed override void _Ready()
    {
        _ReadySystem();
    }

    public sealed override void _Process(double delta)
    {
        if (Paused) return;
        _ProcessSystem(delta);
    }
}