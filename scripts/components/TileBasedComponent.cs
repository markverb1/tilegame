using System;
using Godot;

namespace TileSharp;

[GlobalClass]
public partial class TileBasedComponent : EcsComponent
{
    [Export] public Texture DebugTexture;
    [Export] public Vector2I TilePosition = Vector2I.Zero;
    [Export] public Vector2 TileSize = new(32, 32);
    public override Type[] RequiredComponents { get; } = [];
}