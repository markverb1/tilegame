using Godot;
using System;

namespace TileSharp;

[Icon("uid://dbsfs0dcup33k")]
public partial class Ecs : Node
{
    public static Ecs Instance;

    public override void _Ready()
    {
        Instance = this;
    }
    public EcsEntity AddEntity(EcsResource resource)
    {
        EcsEntity newEntity = new EcsEntity(resource);
        newEntity.SetName(resource.NickName + "_" + newEntity.Id.ToString());
        AddChild(newEntity);
        return newEntity;
    }
}