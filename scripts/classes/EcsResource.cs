using Godot;

namespace TileSharp;

[GlobalClass]
public partial class EcsResource : Resource
{
    [Export] public EcsComponent[] Components;
    [Export] public string FullName;
    [Export] public string NickName;
    [Export] public string[] Systems;
}