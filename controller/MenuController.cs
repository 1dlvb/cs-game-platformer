using Godot;

namespace CS_game_project;

public partial class MenuController: Control
{
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
	}
	private void _on_exit_pressed()
	{
		GD.Print("Exit button");
		GetTree().Quit();
	}
	private void _on_play_pressed()
	{
		GD.Print("Play button");
		GetTree().ChangeSceneToFile("res://Level1.tscn");
	}
	private void _on_back_pressed()
	{
		GD.Print("Back button");
		GetTree().ChangeSceneToFile("res://menu.tscn");
	}
}