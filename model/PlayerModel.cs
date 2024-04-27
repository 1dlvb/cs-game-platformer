using Godot;

namespace CS_game_project;

public partial class PlayerModel : CharacterBody2D
{
	private Vector2 _direction;
	private AnimatedSprite2D _animatedSprite2D;

	private PlayerController _playerController;
	public override void _Ready()
	{
		_playerController = new PlayerController(this);
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		_direction.Y = _playerController.Gravity(delta, _direction);
		_direction.X = _playerController.PlayerMovement(_direction, _animatedSprite2D);
		_direction.Y = _playerController.Jump(_direction, _animatedSprite2D);

		var velocity = Velocity;
		velocity.X = _direction.X;
		velocity.Y = _direction.Y;
		Velocity = velocity;
		MoveAndSlide();
	}
}