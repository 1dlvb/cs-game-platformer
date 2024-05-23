using Godot;

namespace CS_game_project.model;

public partial class PlayerModel : CharacterBody2D
{
	public static bool IsAlive { get; set; } = true;
}