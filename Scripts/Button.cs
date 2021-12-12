using Godot;
using System;

public class Button : Godot.Button
{
    void _on_PlayButton_pressed(){
        GetTree().ChangeScene("res://Levels/Game.tscn");
    }
}
