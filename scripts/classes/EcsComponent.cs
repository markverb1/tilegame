using System;
using Godot;

namespace TileSharp;

[GlobalClass]
[Icon("uid://dtnjjn8c43l0s")]
public abstract partial class EcsComponent : Resource
{
    protected abstract Type[] _requiredComponents { get; }
}