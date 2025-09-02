using Godot;

namespace TileSharp;

[GlobalClass]
public partial class EcsWorldContainer : Control
{
    private static uint _uid;

    public EcsWorld World;
    public uint Id { get; private set; } = ++_uid;
    public Camera2D Camera { get; private set; }

    public override void _Ready()
    {
        Camera = new Camera2D();
        Camera.Enabled = false;
        Camera.SetName("Camera");
        AddChild(Camera);
    }
}