using Godot;
using System;
using NUnit.Framework;

[TestFixture]
public partial class tests : Node
{
	[Test]
	public void AddPoint_Should_IncrementScore()
	{
		var score = new scoreDisplay();
		int oldValue = score.Score;
		score.AddPoint();
		Assert.Equals(oldValue + 1, score.Score);
	}
	
	[Test]

	public void LaunchBall_Should_SetNonZeroVelocity()
	{
		var balle = new BalleRigidBody();
		balle.LaunchBall();
		Assert.Equals(balle.LinearVelocity.Length() > 0, true);
	}

	[Test]

	public void IncreaseSpeed_Should_Work()
	{
		var balle = new BalleRigidBody { Speed = 400f };
		balle.Speed += 50f;
		Assert.Equals(450f, balle.Speed);
	}

	
}
