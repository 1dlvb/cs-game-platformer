using Godot;

namespace CS_game_project;

public partial class Player : CharacterBody2D
{
	private Vector2 _direction;
	private float _movementSpeed = 300f;
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private float _jumpForce = 350.0f;
	private AnimatedSprite2D _myAnimatedSprite2D;
	private bool _isInAir = false;

	public override void _Ready()
	{
		_myAnimatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		// Add the gravity.
		if (!IsOnFloor()) _direction.Y += _gravity * (float)delta;
		
		// Player movement
		_direction.X = Input.GetActionStrength("Right") - Input.GetActionStrength("Left");
		_direction.X *= _movementSpeed;
		
		if(Input.IsActionPressed("Right")) _myAnimatedSprite2D.FlipH = false;
		else if(Input.IsActionPressed("Left")) _myAnimatedSprite2D.FlipH = true;

		if (_direction.X != 0)
		{
			if (!_isInAir) GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("run");
		}
		else
		{
			if (!_isInAir) GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("idle");
		}

		if (IsOnFloor())
		{
			if (Input.IsActionPressed("Up"))
			{
				_direction.Y = -_jumpForce;
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("jump");
				_isInAir = true;
			}
			else _isInAir = false;
			
		}
		
		var velocity = Velocity;
		velocity.X = _direction.X;
		velocity.Y = _direction.Y;
		Velocity = velocity;
		MoveAndSlide();
	}







}