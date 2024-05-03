using System;
using Godot;

namespace CS_game_project;

public partial class PlayerController: CharacterBody2D
{
    private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    private float _movementSpeed = 300f;
    private float _jumpForce = 350.0f;
    private AnimatedSprite2D _animatedSprite2D;
    private bool _isInAir;

    public float PlayerMovement(Vector2 direction, AnimatedSprite2D animatedSprite2D)
    {
        direction.X = Input.GetActionStrength("Right") - Input.GetActionStrength("Left");
        direction.X *= _movementSpeed;

        if (Input.IsActionPressed("Right")) animatedSprite2D.FlipH = false;
        else if (Input.IsActionPressed("Left")) animatedSprite2D.FlipH = true;

        if (direction.X != 0)
        {
            if (!_isInAir) animatedSprite2D.Play("run");
        }
        else
        {
            if (!_isInAir) animatedSprite2D.Play("idle");
        }
        
        return direction.X;
    }

    public float Jump(Vector2 direction, AnimatedSprite2D animatedSprite2D, bool isOnFloor)
    {
        if (!isOnFloor) return direction.Y;
        if (Input.IsActionPressed("Up"))
        {
            direction.Y = -_jumpForce;
            animatedSprite2D.Play("jump");
            _isInAir = true;
        }
        else _isInAir = false;
        return direction.Y;
    }

    public float Gravity(double delta, Vector2 direction, bool isOnFloor)
    {
        if (!isOnFloor) direction.Y += _gravity * (float)delta;
        return direction.Y;
    }
    
}