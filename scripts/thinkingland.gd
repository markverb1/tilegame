extends Node2D

@onready var main = $Main
var astar = AStarGrid2D.new()

func _ready() -> void:
	_on_tilemap_changed()

func get_cell_data(cell: Vector2i, data: String, tilemap: TileMapLayer):
	var currentData = tilemap.get_cell_tile_data(cell)
	if currentData:
		return currentData.get_custom_data(data)
	else:
		return

func _on_tilemap_changed() -> void:
	# Initialize the tilemap
	if not main:
		return
	astar.cell_size = Vector2i(32,32)
	astar.region = main.get_used_rect()
	astar.update()
	for i in main.get_used_cells():
		astar.set_point_solid(i,get_cell_data(i,"Solid",main))
