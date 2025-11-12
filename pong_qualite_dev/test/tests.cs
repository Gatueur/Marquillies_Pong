using Godot;
using System;

public partial class tests : Node
{
	[Test]
	public void AddPoint_Should_IncrementScore()
	{
		var score = new scoreDisplay();
		int oldValue = score.Score;
		score.AddPoint();
		Assert.AreEqual(oldValue + 1, score.Score);
	}
		
	[Test]
	public void LaunchBall_Should_SetNonZeroVelocity()
	{
		var balle = new BalleRigidBody();
		balle.LaunchBall(true);
		Assert.IsTrue(balle.LinearVelocity.Length() > 0);
	}

	[Test]
	public void IncreaseSpeed_Should_Work()
	{
		var balle = new BalleRigidBody { Speed = 400f };
		balle.Speed += 50f;
		Assert.AreEqual(450f, balle.Speed);
	}

	
}
