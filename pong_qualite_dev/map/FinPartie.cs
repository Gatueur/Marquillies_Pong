using Godot;
using System;

public partial class FinPartie : MarginContainer
{
	/*
	*	Fonction retour en arrière à l'appui de la touche "ui_cancel"
	*/
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_cancel")) // "ui_cancel" = touche Échap par défaut
		{
			GetTree().ChangeSceneToFile("res://mainMenu/mainMenu.tscn");
		}
	}
}
