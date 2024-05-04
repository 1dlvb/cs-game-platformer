using System;
using CS_game_project.model;

namespace CS_game_project.view;
using Godot;

public partial class PlayerView : CharacterBody2D
{
    private model.PlayerModel _player;
    private Vector2 _direction;
    private AnimatedSprite2D _animatedSprite2D;
    private controller.PlayerController _playerController;
    public override void _Ready()
    {
        _player = new model.PlayerModel();
        _playerController = new controller.PlayerController();
        _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        
    }
    
    public override void _PhysicsProcess(double delta)
    {
        if (!PlayerModel.IsAlive) QueueFree(); // check if player is died
        _direction.Y = _playerController.Gravity(delta, _direction, IsOnFloor());
        _direction.X = _playerController.PlayerMovement(_direction, _animatedSprite2D);
        _direction.Y = _playerController.Jump(_direction, _animatedSprite2D, IsOnFloor());
    
        var velocity = Velocity;
        velocity.X = _direction.X;
        velocity.Y = _direction.Y;
        Velocity = velocity;
        MoveAndSlide();
    }
}