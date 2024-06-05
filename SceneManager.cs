using Godot;
using System;
using System.Collections.Generic;

public partial class SceneManager : Node2D
{
	[Export]
	private PackedScene playerRosuScene;
	[Export]
	private PackedScene playerAlbastruScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{



		int index = 0;
		foreach(var item in GameManager.Players){
			if(item.Id ==1){
				item.culoare = "rosu";
				var spawnRosu = GetNode<Node2D>("PlayerSpawnPoints/0/spawnRosu");
				Vector2 positionRosu = spawnRosu.GlobalPosition;
				PlayerRosu playerRosu = playerRosuScene.Instantiate<PlayerRosu>();
				playerRosu.Name = item.Id.ToString();
				AddChild(playerRosu);
				playerRosu.GlobalPosition = positionRosu;

			}else if(item.culoare != "albastru"){
				item.culoare= "albastru";
				var spawnAlbastru = GetNode<Node2D>("PlayerSpawnPoints/1/spawnAlbastru");
				Vector2 positionAlbastru = spawnAlbastru.GlobalPosition;
				PlayerAlbastru playerAlbastru = playerAlbastruScene.Instantiate<PlayerAlbastru>();
				playerAlbastru.Name = item.Id.ToString();
				AddChild(playerAlbastru);
				playerAlbastru.GlobalPosition = positionAlbastru;
			}
			index++;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
