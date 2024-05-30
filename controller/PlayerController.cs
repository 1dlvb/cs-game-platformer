using CS_game_project.model;
using CS_game_project.view;
using Godot;

namespace CS_game_project.controller;

public partial class PlayerController: CharacterBody2D
{
    private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    private PlayerModel _player;
    private PlayerView _view;

    public PlayerController()
    {
        _view = new PlayerView();
        _player = new PlayerModel();
    }
    public PlayerController(AnimatedSprite2D animatedSprite2D)
    {
        _player = new PlayerModel();
        _player.AnimatedSprite2D = animatedSprite2D;
    }

    public float PlayerMovement(Vector2 direction, AnimatedSprite2D animatedSprite2D)
    {
        direction.X = Input.GetActionStrength("Right") - Input.GetActionStrength("Left");
        direction.X *= PlayerModel.MovementSpeed;

        if (Input.IsActionPressed("Right")) animatedSprite2D.FlipH = false;
        else if (Input.IsActionPressed("Left")) animatedSprite2D.FlipH = true;

        if (direction.X != 0)
        {
            if (!_player.IsInAir) animatedSprite2D.Play("run");
        }
        else
        {
            if (!_player.IsInAir) animatedSprite2D.Play("idle");
        }
        
        return direction.X;
    }

    public float Jump(Vector2 direction, AnimatedSprite2D animatedSprite2D, bool isOnFloor)
    {
        if (!isOnFloor) return direction.Y;
        if (Input.IsActionPressed("Up"))
        {
            direction.Y = -PlayerModel.JumpForce;
            animatedSprite2D.Play("jump");
            _player.IsInAir = true;
        }
        else _player.IsInAir = false;
        return direction.Y;
    }
   
    public float Gravity(double delta, Vector2 direction, bool isOnFloor)
    {
        if (!isOnFloor) direction.Y += _gravity * (float)delta;
        return direction.Y;
    }

    public static void KillProcess(SnailView snail)
    {
        snail!.Health--;
        if (snail!.Health <= 0) snail!.QueueFree();
    }

    public static void Die(SceneTree tree)
    { 
        tree.ReloadCurrentScene();
    }
}