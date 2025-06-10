extends Control

func _ready() -> void:
	_on_button_toggled(false)

func _on_button_toggled(toggled_on: bool) -> void:
	$Panel.visible = toggled_on

func _on_scale_slider_value_changed(value: float) -> void:
	$SubViewportContainer.stretch_shrink = value
	$Panel/ScaleLabel.text = "Scale = " + str(int(value))
