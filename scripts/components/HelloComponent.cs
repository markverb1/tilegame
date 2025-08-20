using System;
using Godot;

namespace TileSharp;

[GlobalClass]
public partial class HelloComponent : EcsComponent
{
    [Export] public string ThingToPrint = "Hello World";
    [Export] public int TimesToPrint = 1;
    public override Type[] RequiredComponents { get; } = [];
}