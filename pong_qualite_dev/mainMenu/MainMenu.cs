using Godot;
using System;

public partial class MainMenu : MarginContainer
{
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_cancel")) // "ui_cancel" = touche Échap par défaut
		{
			GetTree().Quit();
		}
	}
	
	//Bouton jouer
	private void OnPlayPressed(){
		GetTree().ChangeSceneToFile("res://jeu.tscn");
	}
	
	//Bouton leaderboard
	private void OnLeaderboardPressed(){
		GetTree().ChangeSceneToFile("res://mainMenu/leaderboard.tscn");
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
