using Godot;
using System;

public partial class BalleRigidBody : RigidBody2D
{
	[Export] 
	// Exporte une constante de vitesse pour accéder à la même en tout temps
	public float Speed = 400f;

	public override void _Ready()
	{

		// Direction aléatoire au lancement
		LaunchBall();
		
		// Timer pour augmenter la vitesse toutes les trois secondes
		var timer = new Timer();
		timer.WaitTime = 3f;
		timer.Autostart = true;
		timer.OneShot = false;  // répéter indéfiniment
		timer.Timeout += OnSpeedUp; // Appel de la fonction à la fin du timer
		AddChild(timer);
		}
		
	private void LaunchBall()
	{
		// Crée un vecteur aléatoire pour lancer la balle à l'appel de la fonction (x et y)
		Vector2 dir = new Vector2(
			(float)GD.RandRange(-1.0, 1.0),
			(float)GD.RandRange(-0.5, 0.5)
		).Normalized();

		// La trajectoire de la balle dépend de sa vitesse et de la direction aléatoire
		LinearVelocity = dir * Speed;
	}
	
	private void OnSpeedUp()
	{
		if(Speed >= 600f) {
			Speed = 600f;
			// Limite la vitesse de la balle pour éviter les bugs du moteur de jeu
			// Qui calcule mal les colissions à grande vitesse
		} else { 
			Speed *= 1.02f; // +2% toutes les 3s
		}
		if (LinearVelocity.Length() > 0) {
			// On normalise la vitesse pour éviter les problèmes
			LinearVelocity = LinearVelocity.Normalized() * Speed;
		}
		// Log en cas de débug
		GD.Print("Vitesse augmentée : " + Speed);
	}
 
	private void AddScore(bool rightPlayer)
	{
		// On accède à l’UI pour incrémenter le bon score
		var ui = GetTree().Root.GetNodeOrNull<CanvasLayer>("UI");
		if (ui == null)
		{
			// Test sur l'existence du score
			GD.PrintErr("UI introuvable !");
			return;
		}

		if (rightPlayer)
			ui.GetNode<scoreDisplay>("ScoreRight").AddPoint();
		else
			ui.GetNode<scoreDisplay>("ScoreLeft").AddPoint();
		// Ajout du point au joueur droit ou gauche
	}

	public void ResetBall(bool toRight)
	{
		// Stoppe la balle temporairement
		LinearVelocity = Vector2.Zero;

		// Relance après 0,5 seconde
		GetTree().CreateTimer(0.5).Timeout += () =>
		{
			// Direction aléatoire : X vers droite ou gauche selon toRight, Y aléatoire
			Vector2 dir = new Vector2(toRight ? 1 : -1, (float)GD.RandRange(-0.3f, 0.3f)).Normalized();

			// Reset de la vitesse pour rendre le jeu plus dynamique
			Speed = 400f;
			// Applique la vitesse
			LinearVelocity = dir * Speed;
		};
	}
}
