using Godot;
using TileSharp;

public partial class Viewport : Control
{
    [Export] private SubViewport _subViewport;

    public override void _Ready()
    {
        GD.Print("Hello??");
        Ecs.Instance.ViewportWorldChanged += SwitchWorld;
        var mainWorld = Ecs.Instance.AddWorld("MainWorld");
        Ecs.Instance.AddEntity(GD.Load<EcsResource>("uid://dn6rx3nxdmolu"), mainWorld);
    }

    private void SwitchWorld(EcsWorldContainer worldContainer)
    {
        worldContainer.Camera.CustomViewport = _subViewport;
    }
}