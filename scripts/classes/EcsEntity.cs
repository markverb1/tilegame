using System;
using Godot;

namespace TileSharp;

public partial class EcsEntity : Node
{
    protected EcsResource EntityResource { get; }

    public EcsEntity()
    {
    }

    public EcsEntity(EcsResource entityResource, bool autoCreateSystems = false)
    {
        EntityResource = entityResource;
    }

    public bool CreateSystems()
    {
        if (EntityResource == null) return false;
        foreach (var system in EntityResource.Systems)
        {
            Type systemType = Type.GetType($"TileSharp.Scripts.Systems.{system}");
            if (systemType != null)
            {
                var newSystem = Activator.CreateInstance(systemType) as EcsSystem;
                if (newSystem == null) break;
                newSystem.SetName(system);
                AddChild(newSystem);
            }
            else
            {
                GD.PrintErr($"Cannot create system of type {system}");
            }
        }
        return true;
    }
}