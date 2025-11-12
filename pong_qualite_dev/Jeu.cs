using Godot;
using System;

public partial class Jeu : Node2D
{
	public override void _Ready()
	{
		// Récupère la Map instanciée
		var map = GetNode<Node2D>("Map");

		// Récupère les buts à l'intérieur de la map
		var butGauche = map.GetNode<Area2D>("ButGauche");
		var butDroit = map.GetNode<Area2D>("ButDroit");

		// Connecte le signal body_entered de chaque but pour détecter les collisiosn entrantes
		butGauche.BodyEntered += (Node2D body) =>
		{
			if (body is BalleRigidBody balle)
			{
				// Ajout d'un point avant le reset de la balle
				GetNode<scoreDisplay>("UI/Right").AddPoint();
				balle.ResetBall(toRight: true);
			}
		};
		
		// Connecte le signal body_entered de chaque but pour détecter les collisiosn entrantes
		butDroit.BodyEntered += (Node2D body) =>
		{
			if (body is BalleRigidBody balle)
			{
				// Ajout d'un point avant le reset de la balle
				GetNode<scoreDisplay>("UI/Left").AddPoint();
				balle.ResetBall(toRight: false);
			}
		};
	}
}
