using System;
using Godot;

namespace TileSharp;

[Icon("uid://ggb7uwkqatyl")]
public partial class EcsEntity : Node
{
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

    public EcsResource EntityResource { get; protected set; }
    public EcsContainer EcsContainer { get; protected set; }

    public bool AutoCreateSystems()
    {
        if (EntityResource == null) return false;
        foreach (var system in EntityResource.Systems)
        {
            var systemType = Type.GetType($"TileSharp.{system}");
            if (systemType != null)
            {
                var newSystem = Activator.CreateInstance(systemType) as EcsSystem;
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

    public EcsComponent GetComponent(Type componentType, bool throwErrorIfNotFound = false)
    {
        var component = Array.Find(EntityResource.Components, c => c.GetType() == componentType);
        if (throwErrorIfNotFound && component == null)
            throw new InvalidOperationException("Cannot find component of type " + nameof(componentType));
        return component;
    }

    public T GetComponent<T>(bool throwErrorIfNotFound = false) where T : EcsComponent
    {
        var component = Array.Find(EntityResource.Components, c => c.GetType() == typeof(T));
        if (throwErrorIfNotFound && component == null)
            throw new InvalidOperationException("Cannot find component of type " + nameof(T));
        return (T)component;
    }

    public bool HasComponent(Type componentType, bool throwErrorIfNotFound = false)
    {
        return GetComponent(componentType, throwErrorIfNotFound) != null;
    }

    public bool HasComponent<T>(bool throwErrorIfNotFound = false) where T : EcsComponent
    {
        return GetComponent<T>(throwErrorIfNotFound) != null;
    }

    public bool HasSystem(Type systemType, bool throwErrorIfNotFound = false)
    {
        foreach (var system in GetChildren())
            if (system.GetType() == systemType)
                return true;

        if (throwErrorIfNotFound) throw new Exception($"Cannot find system of type {systemType}");

        return false;
    }

    public bool HasSystem<T>(bool throwErrorIfNotFound = false) where T : Type
    {
        foreach (var system in GetChildren())
            if (system.GetType() == typeof(T))
                return true;

        if (throwErrorIfNotFound) throw new Exception($"Cannot find system of type {typeof(T)}");

        return false;
    }

    public EcsSystem GetSystem(Type systemType, bool throwErrorIfNotFound = false)
    {
        foreach (var system in GetChildren())
            if (system.GetType() == systemType)
                return (EcsSystem)system;

        if (throwErrorIfNotFound)
            throw new Exception($"Cannot find system of type {systemType}");

        return null;
    }

    public T GetSystem<T>(bool throwErrorIfNotFound = false) where T : EcsSystem
    {
        foreach (var system in GetChildren())
            if (system is T typedSystem)
                return typedSystem;

        if (throwErrorIfNotFound)
            throw new Exception($"Cannot find system of type {typeof(T)}");

        return null;
    }


    public bool SystemInitialised(Type systemType, bool throwErrorIfNotFound = false)
    {
        var system = GetSystem(systemType, throwErrorIfNotFound);
        if (system == null) return false;
        return system.Initialised;
    }

    public bool SystemInitialised<T>(bool throwErrorIfNotFound = false) where T : EcsSystem
    {
        var system = GetSystem<T>(throwErrorIfNotFound);
        if (system == null)
            return false;

        return system.Initialised;
    }
}