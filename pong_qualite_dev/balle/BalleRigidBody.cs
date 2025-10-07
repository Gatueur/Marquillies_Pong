using Godot;
using System;

public partial class BalleRigidBody : RigidBody2D
{
	[Export]
	public float Speed = 400f;

	public override void _Ready()
	{
		// Direction random au début
		Vector2 dir = new Vector2(
			(float)GD.RandRange(-1.0, 1.0),
			(float)GD.RandRange(-0.5, 0.5)
		).Normalized();
		// Défini la direction de la balle au début selon un vecteur random

		LinearVelocity = dir * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		if (LinearVelocity.Length() != 0)
		{
			LinearVelocity = LinearVelocity.Normalized() * Speed;
		}
	}
	
	private void OnBodyEntered(Node body)
	{
		// Exemple : +5% de vitesse à chaque collision
		Speed *= 1.05f;
	}

	//Faudra l'appeler quand on aura tout au même endroit dcp
	public void ResetBall()
	{
		GlobalPosition = GetViewportRect().Size / 2;

		Vector2 dir = new Vector2(
			(float)GD.RandRange(-1.0, 1.0),
			(float)GD.RandRange(-0.5, 0.5)
		).Normalized();
		// Défini la direction de la balle au reset

		LinearVelocity = dir * Speed;
	}
}
