using System;
using CS_game_project.view;
using Godot;

namespace CS_game_project.controller;

public partial class FinishController : Area2D
{
	// Called when the Area2D node enters another body
	public override void _PhysicsProcess(double delta)
	{
		foreach (var area in GetOverlappingAreas())
		{
			if (area.Name != "PlayerArea2D") continue;
			// PlayerView is the script attached to the player node
			// Implement the necessary actions when the enemy collides with the player
			string currentScene = GetTree().CurrentScene.Name;
			GD.Print(currentScene);
			GD.Print();
			GetTree().ChangeSceneToFile($"res://Level{ Convert.ToInt32(currentScene[5..])+1}.tscn");
		}	
	}

	// Connect to the body_entered signal
	public override void _Ready()
	{
	}
}