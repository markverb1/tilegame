using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace TileSharp;

[GlobalClass]
[Icon("uid://6c6y86sigj40")]
public abstract partial class EcsSystem : Node
{
    public EcsEntity myEntity;
    public bool Paused = false;

    /// <summary>
    ///     Creates an EcsSystem. Starts off paused, add an entity and set paused to false in order to start the system.
    /// </summary>
    public EcsSystem()
    {
    }

    public abstract Type[] RequiredComponents { get; }
    public abstract Type[] RequiredSystems { get; }
    public abstract PackedScene Scene { get; }
    public bool Initialised { get; protected set; } = false;

    protected abstract void _ReadySystem();
    protected abstract void _ProcessSystem(double delta);

    public void SetPaused(bool pause)
    {
        Paused = pause;
    }

    public bool SearchSystemDependencies(Type query, bool searchSelf = true, HashSet<Type> visited = null)
    {
        visited ??= new HashSet<Type>();
        if (RequiredSystems.Contains(query) && searchSelf)
        {
            if (visited.Contains(query))
                throw new Exception($"Circular dependency detected in system {GetType().Name}");

            return true;
        }

        var queriedSystem = Activator.CreateInstance(query) as EcsSystem;
        if (queriedSystem == null) return false;

        foreach (var system in queriedSystem.RequiredSystems)
        {
            if (visited.Contains(system))
                throw new Exception($"Circular dependency detected in system {nameof(system)}");

            visited.Add(system);

            if (SearchSystemDependencies(system, true, visited)) return true;
        }

        return false;
    }

    public sealed override void _Ready()
    {
        if (GetParent() is EcsEntity)
        {
            myEntity = (EcsEntity)GetParent();
            Paused = false;
        }

        foreach (var system in RequiredSystems) SearchSystemDependencies(system, false);

        foreach (var comp in RequiredComponents) myEntity.GetComponent(comp, true);

        foreach (var system in RequiredSystems)
            if (!myEntity.SystemInitialised(system))
            {
                Paused = true;
                break;
            }

        _ReadySystem();
    }

    public sealed override void _Process(double delta)
    {
        if (Paused) return;
        _ProcessSystem(delta);
    }
}