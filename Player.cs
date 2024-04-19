using Godot;

namespace CS_game_project;

public partial class Player : CharacterBody2D
{
	private Vector2 _direction;
	private float _movementSpeed = 300f;
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private float _jumpForce = 350.0f;
	

	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		// Add the gravity.
		if (!IsOnFloor())
			_direction.Y += _gravity * (float)delta;
		
		// Player movement
		_direction.X = Input.GetActionStrength("Right") - Input.GetActionStrength("Left");
		_direction.X *= _movementSpeed;

		if (IsOnFloor() && Input.IsActionPressed("Up")) _direction.Y = -_jumpForce;
		
		var velocity = Velocity;
		velocity.X = _direction.X;
		velocity.Y = _direction.Y;
		Velocity = velocity;
		MoveAndSlide();
	}







}