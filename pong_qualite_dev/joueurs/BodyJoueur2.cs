using Godot;
using System;

public partial class BodyJoueur2 : CharacterBody2D
{
	// Vitesse par défaut et touches de mouvement
	[Export] public float Speed = 400f;
	[Export] public string UpAction = "ui_up";
	[Export] public string DownAction = "ui_down";

	public override void _PhysicsProcess(double delta)
	{
		// Gestion du haut/bas du joueur
		float move = 0f;
		if (Input.IsActionPressed(UpAction)) move -= 1f;
		if (Input.IsActionPressed(DownAction)) move += 1f;

		// Garde X fixe, ne bouge que sur Y 
		Velocity = new Vector2(0, move * Speed);
		MoveAndSlide();

		// Sécurité : repositionne X au cas où
		GlobalPosition = new Vector2(FixedX, GlobalPosition.Y);
	}
	// Valeur fixe pour la position
	private float FixedX;

	public override void _Ready()
	{
		FixedX = GlobalPosition.X;
	}
}
