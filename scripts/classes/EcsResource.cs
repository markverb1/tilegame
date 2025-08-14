using Godot;

namespace TileSharp;

[GlobalClass]
[Icon("uid://crtmqa418ve3r")]
public partial class EcsResource : Resource
{
    [Export] public EcsComponent[] Components;
    [Export] public string FullName;
    [Export] public string NickName;
    [Export] public string[] Systems;
}