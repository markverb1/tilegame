using Godot;
using System;

namespace TileSharp;

[GlobalClass]
public partial class HelloComponent : EcsComponent
{
    protected override Type[] _requiredComponents { get; } = [];
    [Export] public string ThingToPrint = "Hello World";
    [Export] public int TimesToPrint = 1;
}