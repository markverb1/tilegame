using System;

namespace TileSharp;

public partial class TileHelloComponent : EcsComponent
{
    public override Type[] RequiredComponents { get; } = [];
}