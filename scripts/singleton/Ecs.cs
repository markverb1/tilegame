using Godot;

namespace TileSharp;

public partial class Ecs : Node
{
    [Signal]
    public delegate void ViewportWorldChangedEventHandler(EcsWorldContainer worldContainer);

    public static Ecs Instance;
    public EcsWorld DefaultWorld;

    public override void _Ready()
    {
        Instance = this;
    }

    public EcsEntity AddEntity(EcsResource resource, EcsWorld world = null)
    {
        if (world == null) world = DefaultWorld;
        var newEntity = new EcsEntity(resource, true);
        newEntity.SetName(resource.NickName + "_" + newEntity.Id);
        world.AddChild(newEntity);
        return newEntity;
    }

    public EcsWorld AddWorld(string name)
    {
        var world = new EcsWorld();
        world.WorldName = name;
        world.SetName($"{name}_{world.Id}");
        AddChild(world);
        var worldContainer = new EcsWorldContainer();
        worldContainer.SetName(name);
        world.AddChild(worldContainer);
        world.WorldContainer = worldContainer;
        worldContainer.World = world;
        return world;
    }

    public EcsWorld FindWorldById(int id)
    {
        foreach (EcsWorld world in GetChildren())
            if (world.Id == id)
                return world;

        return null;
    }


    public void ChangeViewportWorld(EcsWorldContainer worldContainer)
    {
        EmitSignal("ViewportWorldChanged", worldContainer);
    }
}