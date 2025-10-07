using Godot;
using System;

// Script de la scène Credits
public partial class Credits : MarginContainer
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
