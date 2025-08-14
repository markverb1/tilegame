using Godot;

namespace TileSharp;

public partial class Main : Node2D
{
    public override void _Ready()
    {
        GD.Print("Hello Microsoft");
        GD.Print(nameof(HelloComponent));
    }

    public override void _Process(double delta)
    {
    }
}