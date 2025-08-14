using System;
using Godot;

namespace TileSharp;

[GlobalClass]
public abstract partial class EcsComponent : Resource
{
    protected abstract Type[] _requiredComponents { get; }
}