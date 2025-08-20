using System;

namespace TileSharp;

public partial class TileBasedComponent : EcsComponent
{
    public override Type[] RequiredComponents { get; } = [];
}