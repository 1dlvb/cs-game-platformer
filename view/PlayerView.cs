using CS_game_project.controller;
using CS_game_project.model;

namespace CS_game_project.view;
using Godot;

public partial class PlayerView : CharacterBody2D
{
    private PlayerModel _player;
    private Vector2 _direction;
    private AnimatedSprite2D _animatedSprite2D;
    private PlayerController _playerController;
    private const float BounceStrength = 300f; // Adjust the bounce strength as needed


    public override void _Ready()
    {
        _player = new PlayerModel();
        _playerController = new PlayerController();
        _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }
    
    public override void _PhysicsProcess(double delta)
    {
        // Check for collisions
        _direction.Y = _playerController.Gravity(delta, _direction, IsOnFloor());
        _direction.X = _playerController.PlayerMovement(_direction, _animatedSprite2D);
        _direction.Y = _playerController.Jump(_direction, _animatedSprite2D, IsOnFloor());
        
        // Bounce logic
        for (var i = 0; i < GetSlideCollisionCount(); i++)
        {
            var collision = GetSlideCollision(i);
            if (collision?.GetCollider() is not SnailView) continue;
            var snail = collision.GetCollider() as SnailView;
            _direction.Y = -BounceStrength; // Apply bounce effect
            PlayerController.KillProcess(snail);
            break;
        }

        var velocity = Velocity;
        velocity.X = _direction.X;
        velocity.Y = _direction.Y;
        Velocity = velocity;
        MoveAndSlide();
    }
}