using Godot;
using System;
using System.Collections.Generic;

public partial class scoreDisplay : Node2D
{
	[Export] public Sprite2D Digit1;
	[Export] public Sprite2D Digit2;

	// Dictionnaire pour relier un chiffre à son image
	private Dictionary<int, Texture2D> numberTextures = new();

	public int Score { get; private set; } = 0;

	public override void _Ready()
	{
		// Charge les textures des chiffres
		for (int i = 0; i <= 9; i++)
		{
			var tex = GD.Load<Texture2D>($"res://assets/sprites/numbers/{i}.png");
			numberTextures[i] = tex;
		}
		// Mise à jour de l'affichage du score
		UpdateDisplay();
	}

	public void AddPoint()
	{
		Score++;
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		int tens = Score / 10;
		int ones = Score % 10;

		if (Digit1 != null)
			Digit1.Texture = numberTextures[tens];

		if (Digit2 != null)
			Digit2.Texture = numberTextures[ones];
		
		if (Score == 10){
			GetTree().ChangeSceneToFile("res://map//finPartie.tscn");
		}
	}

	public void ResetScore()
	{
		Score = 0;
		UpdateDisplay();
	}
}
