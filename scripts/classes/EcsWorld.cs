using Godot;

namespace TileSharp;

public partial class EcsWorld : Node
{
    private static uint _uid;
    public EcsWorldContainer WorldContainer;
    public StringName WorldName = "World";
    public uint Id { get; private set; } = ++_uid;
}