using System;
using Godot;
using System.Diagnostics.CodeAnalysis;

namespace TileSharp;

[Icon("uid://ggb7uwkqatyl")]
public partial class EcsEntity : Node
{
    public EcsResource EntityResource { get; protected set; }
    private static uint _uid = 0;
    public uint Id = ++_uid;


    private EcsEntity()
    {
    }

    public EcsEntity(EcsResource entityResource, bool autoCreateSystems = false)
    {
        EntityResource = entityResource;
        if (autoCreateSystems) AutoCreateSystems();
    }

    public bool AutoCreateSystems()
    {
        if (EntityResource == null) return false;
        foreach (var system in EntityResource.Systems)
        {
            Type systemType = Type.GetType($"TileSharp.Scripts.Systems.{system}");
            if (systemType != null)
            {
                var newSystem = Activator.CreateInstance(systemType, this) as EcsSystem;
                AddSystem(newSystem);
            }
            else
            {
                GD.PrintErr($"Cannot create system of type {system}");
            }
        }

        return true;
    }

    public bool AddSystem(EcsSystem newSystem)
    {
        if (newSystem == null) return false;
        newSystem.SetName(newSystem.GetType().Name);
        AddChild(newSystem);
        return true;
    }
}