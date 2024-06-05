using CS_game_project.view;
using Godot;

namespace CS_game_project.controller;

public partial class SnailController : Node
{
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private CS_game_project.PlayerController _playerController = new();

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
	public static void Kill(Area2D collisionArea, SceneTree tree)
	{
		foreach (var area in collisionArea.GetOverlappingAreas())
		{
			if (area.Name != "PlayerArea2D") continue;
			CS_game_project.PlayerController.Die(tree);
		}
	}
}
