using Godot;
using System;

public class GameStat : Panel
{
    Label state;
    Label hits;
    Node main;
    Button next;

    public override void _Ready()
    {
        state = GetNode<Label>("State");
        hits = GetNode<Label>("Hits");

        Owner.Connect("victory", this, "victory");
        Owner.Connect("lose", this, "lose");
    }

    public void victory(){
        state.Text = "Victory";
        hits.Text = (GameManager.hitMax - GameManager.hitLeft).ToString();
        this.Visible = true;
    }

    public void lose(){
        state.Text = "Lose";
        hits.Text = "";
        this.Visible = true;
    }

    public void _on_Next_pressed(){
        GetTree().ChangeScene("res://Levels/DifficultySelector.tscn");
    }
}
