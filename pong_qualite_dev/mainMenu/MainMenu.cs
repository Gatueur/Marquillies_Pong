using Godot;
using System;

// Script de la scène MainMenu
public partial class MainMenu : MarginContainer
{
	/*
	*	Fonction qui ferme le jeu à l'appui de la touche "ui_cancel"
	*/
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_cancel")) // "ui_cancel" = touche Échap par défaut
		{
			GetTree().Quit(); // Fermer le jeu
		}
	}
	
	//Bouton jouer
	private void OnPlayPressed(){
		GetTree().ChangeSceneToFile("res://map/map.tscn");
	}
	
	//Bouton quitter
	private void OnLeavePressed(){
		GetTree().Quit();
	}
	
	//Bouton credits
	private void OnCreditsPressed(){
		GetTree().ChangeSceneToFile("res://mainMenu/credits.tscn");
	}
}
