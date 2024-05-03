using Godot;

namespace CS_game_project.view;

public partial class SnailView : CharacterBody2D
{
	private const float Speed = 25.0f;
	private bool _movingRight = true;
	private AnimatedSprite2D _animatedSprite2D;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;
		if (!IsOnFloor()) velocity.Y = _gravity * (float)delta;
		if (IsOnWall())
		{
			GD.Print("Hit");
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

		Velocity = velocity;
		MoveAndSlide();
	}
}