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
	// Position au centre exact du viewport (X et Y)
	GlobalPosition = GetViewportRect().Size / 2;

	// Stoppe la balle temporairement
	LinearVelocity = Vector2.Zero;

	// Relance après 0,5 seconde
	GetTree().CreateTimer(0.5).Timeout += () =>
	{
		// Direction aléatoire : X vers droite ou gauche selon toRight, Y aléatoire
		Vector2 dir = new Vector2(toRight ? 1 : -1, (float)GD.RandRange(-0.3f, 0.3f)).Normalized();

		// Applique la vitesse
		LinearVelocity = dir * Speed;
	};
}

}
