using System;
using Godot;

namespace TileSharp;

[GlobalClass]
public partial class TileBasedComponent : EcsComponent
{
    public override Type[] RequiredComponents { get; } = [];
}