using CS_game_project.controller;
using Godot;

namespace CS_game_project.view;

public partial class SnailView : CharacterBody2D
{
	private const float Speed = 25.0f;
	private bool _movingRight = true;
	private AnimatedSprite2D _animatedSprite2D;
	private PlayerController _playerController;
	private PlayerView _playerView;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_playerController = new PlayerController();
		_playerView = new PlayerView();
	}

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;
		if (!IsOnFloor()) velocity.Y = _gravity * (float)delta;
		if (IsOnWall())
		{
			_movingRight = !_movingRight; // Change direction when hitting a wall
		}

		if (_movingRight)
		{
			_animatedSprite2D.FlipH = true;
			velocity.X = Speed; // Move right
		}
		else
		{
			_animatedSprite2D.FlipH = false;
			velocity.X = -Speed; // Move left
		}
		
		foreach (var area in GetNode<Area2D>("HitboxArea").GetOverlappingAreas())
		{
			if (area.Name != "PlayerArea2D") continue;
			// PlayerView is the script attached to the player node
			// Implement the necessary actions when the enemy collides with the player
			Die();
		}
		
		foreach (var area in GetNode<Area2D>("CollisionArea").GetOverlappingAreas())
		{
			if (area.Name != "PlayerArea2D") continue;
			// PlayerView is the script attached to the player node
			// Implement the necessary actions when the enemy collides with the player
			PlayerController.Die();
		}
			
		Velocity = velocity;
		MoveAndSlide();
	}
	private void Die()
	{
		QueueFree(); // Destroy the enemy node
	}
	
}