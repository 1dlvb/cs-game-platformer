using Godot;

namespace CS_game_project.model;

public partial class PlayerModel : CharacterBody2D
{
	public static bool IsAlive { get; set; } = true;
	public static float MovementSpeed => 300f;
	public static float JumpForce => 350.0f;
	public AnimatedSprite2D AnimatedSprite2D { get; set; }
	public bool IsInAir { get; set; }
}