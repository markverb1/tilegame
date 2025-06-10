extends Control

@onready var debug_container = $Debugs

func create_debug(debug_name: String) -> Node:
	var label = Label.new()
	label.name = debug_name
	debug_container.add_child(label)
	return label

func remove_debug(debug_name: String) -> void:
	var debug = debug_container.find_child(debug_name)
	if not debug:
		return
	debug.queue_free()

func set_debug(debug_name: String, text: String, create_if_missing: bool = false) -> void:
	var debug = get_node_or_null("Debugs/"+debug_name)
	if not create_if_missing and debug == null:
		return
	elif create_if_missing and debug == null:
		debug = create_debug(debug_name)
	debug.text = debug_name + " = " + text

func _ready() -> void:
	_on_button_toggled(false)
	manager.cursor_position_changed.connect(_on_cursor_position_changed)

func _on_button_toggled(toggled_on: bool) -> void:
	$Panel.visible = toggled_on

func _on_scale_slider_value_changed(value: float) -> void:
	$SubViewportContainer.stretch_shrink = value
	$Panel/ScaleLabel.text = "Scale = " + str(int(value))

func _on_cursor_position_changed(pos: Vector2):
	set_debug("Cursor Pos",str(Vector2i(pos)/32),true)
