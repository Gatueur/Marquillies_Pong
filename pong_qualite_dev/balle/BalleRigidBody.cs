using Godot;
using System;

public partial class BalleRigidBody : RigidBody2D
{
	[Export]
	public float Speed = 400f;

	public override void _Ready()
	{
		// Connexion automatique pour détecter les collisions avec d'autres corps
		BodyEntered += OnBodyEntered;

		// Direction aléatoire au lancement
		LaunchBall();
	}

	private void LaunchBall()
	{
		Vector2 dir = new Vector2(
			(float)GD.RandRange(-1.0, 1.0),
			(float)GD.RandRange(-0.5, 0.5)
		).Normalized();

		LinearVelocity = dir * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		// Maintient la vitesse constante
		if (LinearVelocity.Length() != 0)
		{
			LinearVelocity = LinearVelocity.Normalized() * Speed;
		}
	}

	private void OnBodyEntered(Node body)
	{
			Speed *= 1.05f;
	}

	private void AddScore(bool rightPlayer)
	{
		// On accède à l’UI pour incrémenter le bon score
		var ui = GetTree().Root.GetNodeOrNull<CanvasLayer>("UI");
		if (ui == null)
		{
			GD.PrintErr("UI introuvable !");
			return;
		}

		if (rightPlayer)
			ui.GetNode<scoreDisplay>("ScoreRight").AddPoint();
		else
			ui.GetNode<scoreDisplay>("ScoreLeft").AddPoint();
	}

	public void ResetBall(bool toRight)
	{
		// Replace la balle au centre
		GlobalPosition = GetViewportRect().Size / 2;

		// Petite pause avant de relancer (optionnel)
		GetTree().CreateTimer(0.5).Timeout += () =>
		{
			// Direction selon le joueur qui vient d’encaisser
			Vector2 dir = (toRight ? Vector2.Right : Vector2.Left) +
						  new Vector2(0, (float)GD.RandRange(-0.3, 0.3f));
			dir = dir.Normalized();

			LinearVelocity = dir * Speed;
		};
	}
}
