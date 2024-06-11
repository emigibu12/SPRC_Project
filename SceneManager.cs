using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SceneManager : Node2D
{
	[Export]
	private PackedScene playerRosuScene;
	[Export]
	private PackedScene playerAlbastruScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bool existaRosu = GameManager.Players.Any(p => p.culoare == "rosu");
		bool existaAlbastru = GameManager.Players.Any(p => p.culoare == "albastru");
		foreach (var item in GameManager.Players)
		{
			if(item.Id == 1){
				continue;
			}
			// Dacă nu există un jucător roșu și jucătorul curent nu este roșu, îl facem roșu
			if (!existaRosu && item.culoare != "rosu")
			{
				item.culoare = "rosu";
				var spawnRosu = GetNode<Node2D>("PlayerSpawnPoints/0/spawnRosu");
				Vector2 positionRosu = spawnRosu.GlobalPosition;
				PlayerRosu playerRosu = playerRosuScene.Instantiate<PlayerRosu>();
				playerRosu.Name = item.Id.ToString();
				AddChild(playerRosu);
				playerRosu.GlobalPosition = positionRosu;
				existaRosu = true; // Marcăm că acum avem un jucător roșu
			}
			// Dacă nu există un jucător albastru și jucătorul curent nu este albastru, îl facem albastru
			if (!existaAlbastru && item.culoare != "albastru")
			{
				item.culoare = "albastru";
				var spawnAlbastru = GetNode<Node2D>("PlayerSpawnPoints/1/spawnAlbastru");
				Vector2 positionAlbastru = spawnAlbastru.GlobalPosition;
				PlayerAlbastru playerAlbastru = playerAlbastruScene.Instantiate<PlayerAlbastru>();
				playerAlbastru.Name = item.Id.ToString();
				AddChild(playerAlbastru);
				playerAlbastru.GlobalPosition = positionAlbastru;
				existaAlbastru = true; // Marcăm că acum avem un jucător albastru
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	
}
