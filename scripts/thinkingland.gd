extends Node2D

@onready var main = $Main
var astar = AStarGrid2D.new()

func _ready() -> void:
	_on_tilemap_changed()
	pathfind(Vector2i(0,0),Vector2i(10,10))

func pathfind(origin: Vector2i, target: Vector2i, heuristic: AStarGrid2D.Heuristic = AStarGrid2D.HEURISTIC_MANHATTAN, diagonal_type: AStarGrid2D.DiagonalMode = AStarGrid2D.DIAGONAL_MODE_NEVER):
	astar.default_compute_heuristic = heuristic
	astar.diagonal_mode = diagonal_type
	astar.update()
	var returning
	if not (astar.region.has_point(origin) and astar.region.has_point(target)):
		# this is dumb
		astar.region = astar.region.expand(origin + Vector2i.ONE)
		astar.region = astar.region.expand(target + Vector2i.ONE)
		astar.update()
		returning = astar.get_point_path(origin,target)
		_on_tilemap_changed()
	else:
		returning = astar.get_point_path(origin,target)
	return returning
	
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
	astar.region = astar.region.expand(Vector2i(0,0))
	astar.update()
	for i in main.get_used_cells():
		astar.set_point_solid(i,get_cell_data(i,"Solid",main))
