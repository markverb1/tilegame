using Godot;

namespace TileSharp;

public partial class Main : Node2D
{
    public override void _Ready()
    {
        Ecs.Instance.AddEntity(GD.Load<EcsResource>("uid://dn6rx3nxdmolu"));
    }

    public override void _Process(double delta)
    {
    }
}