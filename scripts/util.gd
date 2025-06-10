extends Node

func floorsnap(x: float, step: float):
	return floor(x/step)*step

func floorsnapv2(x: Vector2, step: float):
	return Vector2(floor(x.x/step)*step,floor(x.y/step)*step)
