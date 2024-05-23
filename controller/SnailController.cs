using CS_game_project.model;
using CS_game_project.view;
using Godot;

namespace CS_game_project.controller;

public partial class SnailController : Node
{
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private float Gravity(double delta, Vector2 direction, bool isOnFloor)
	{
		if (!isOnFloor) direction.Y += _gravity * (float)delta;
		return direction.Y;
	}
	public Vector2 CalculateVelocity(double d, Vector2 velocity, SnailView snail, AnimatedSprite2D sprite)
	{
		if (!snail.IsOnFloor()) velocity.Y = _gravity * (float)d;
		if (snail.IsOnWall())
		{
			snail.MovingRight = !snail.MovingRight; // Change direction when hitting a wall
		}

		if (snail.MovingRight)
		{
			sprite.FlipH = true;
			velocity.X = SnailView.Speed; // Move right
		}
		else
		{
			sprite.FlipH = false;
			velocity.X = -SnailView.Speed; // Move left
		}
		
		return velocity;
	}
	public static bool ProcessDying(Area2D hitboxArea, Area2D collisionArea)
	{
		var snailIsDied = false;
		foreach (var area in hitboxArea.GetOverlappingAreas())
		{
			if (area.Name != "PlayerArea2D") continue;
			snailIsDied = true;
		}

		foreach (var area in collisionArea.GetOverlappingAreas())
		{
			if (area.Name != "PlayerArea2D") continue;
			PlayerController.Die();
		}
		return snailIsDied;
	}
}
