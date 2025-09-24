using Godot;
using System;

public partial class Credits : MarginContainer
{
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_cancel")) // "ui_cancel" = touche Échap par défaut
		{
			GetTree().ChangeSceneToFile("res://mainMenu/mainMenu.tscn");
		}
	}
}
