using Godot;
using System;

public partial class BalleRigidBody : RigidBody2D
{
	[Export]
	public float Speed = 400f;

	public override void _Ready()
	{

		// Direction aléatoire au lancement
		LaunchBall();
		
		// Timer pour augmenter la vitesse toutes les 5 secondes
		var timer = new Timer();
		timer.WaitTime = 3f;    // 3 secondes
		timer.Autostart = true;
		timer.OneShot = false;  // répéter indéfiniment
		timer.Timeout += OnSpeedUp;
		AddChild(timer);
		}
		
	private void LaunchBall()
	{
		Vector2 dir = new Vector2(
			(float)GD.RandRange(-1.0, 1.0),
			(float)GD.RandRange(-0.5, 0.5)
		).Normalized();

		LinearVelocity = dir * Speed;
	}
	
	private void OnSpeedUp()
	{
		if(Speed >= 600f) {
			Speed = 600f;
			GD.Print("On garde la même vitesse");
		} else { 
			Speed *= 1.02f; // +2% toutes les 3s
		}
		if (LinearVelocity.Length() > 0) {
			LinearVelocity = LinearVelocity.Normalized() * Speed;
		}
		GD.Print("Vitesse augmentée : " + Speed);
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

			Speed = 400f;
			// Applique la vitesse
			LinearVelocity = dir * Speed;
		};
	}
}
