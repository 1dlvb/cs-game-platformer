using Godot;

namespace CS_game_project.controller;

public partial class SnailController : Node
{
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public float Gravity(double delta, Vector2 direction, bool isOnFloor)
	{
		if (!isOnFloor) direction.Y += _gravity * (float)delta;
		return direction.Y;
	}
}