using CS_game_project.controller;
using CS_game_project.model;
using Godot;

namespace CS_game_project.view;

public partial class SnailView : CharacterBody2D
{
	public const float Speed = 25.0f;
	public bool MovingRight { get; set; } = true;
	private PlayerController _playerController;
	private SnailController _snailController;
	private SnailModel _snailModel;
	private PlayerView _playerView;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{

		_snailModel = new SnailModel();
		_snailModel.SnailAnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_playerController = new PlayerController();
		_playerView = new PlayerView();
		_snailController = new SnailController();
	}

	public override void _PhysicsProcess(double delta)
	{
		var velocity = _snailController.CalculateVelocity(delta, Velocity, this, _snailModel.SnailAnimatedSprite);
		var snailIsDied = SnailController.ProcessDying(GetNode<Area2D>("HitboxArea"),
			GetNode<Area2D>("CollisionArea"));
		if (snailIsDied) Die();

		Velocity = velocity;
		MoveAndSlide();
	}
	
	private void Die()
	{
		QueueFree(); // Destroy the enemy node
	}
}