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

		LinearVelocity = dir * Speed;
	}

	//Faudra l'appeler quand on aura tout au même endroit dcp
	public void ResetBall()
	{
		GlobalPosition = GetViewportRect().Size / 2;

		Vector2 dir = new Vector2(
			(float)GD.RandRange(-1.0, 1.0),
			(float)GD.RandRange(-0.5, 0.5)
		).Normalized();

		LinearVelocity = dir * Speed;
	}
}
