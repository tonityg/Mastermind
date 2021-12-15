using Godot;
using System;

public class GameStat : Panel
{
    Label state;
    Label hits;
    Node main;
    Button next;
    Label xpWon;

    public override void _Ready()
    {
        state = GetNode<Label>("State");
        hits = GetNode<Label>("Hits");
        xpWon = GetNode<Label>("XPWon");

        Owner.Connect("victory", this, "victory");
        Owner.Connect("lose", this, "lose");
    }

    public void victory(){
        state.Text = "Victory";
        hits.Text = (GameManager.hitMax - GameManager.hitLeft).ToString();
        if(GameManager.difficulty == 1){
            if(GameManager.hitLeft > GameManager.hitMax/2 && GameManager.hitLeft <= GameManager.hitMax){
                GameManager.currentXp += GameManager.xpNovice;
                xpWon.Text = GameManager.currentXp.ToString();
                GD.Print("trois étoiles");
            }else if(GameManager.hitLeft > GameManager.hitMax/3 && GameManager.hitLeft <= GameManager.hitMax/2){
                GameManager.currentXp += (int) (GameManager.xpNovice * 0.75);
                xpWon.Text = GameManager.currentXp.ToString();
                GD.Print("deux étoiles");
            }else{
                GameManager.currentXp += (int) (GameManager.xpNovice * 0.5);
                xpWon.Text = GameManager.currentXp.ToString();
                GD.Print("une étoile : ");
            }  
        }else if(GameManager.difficulty == 2){
            if(GameManager.hitLeft > GameManager.hitMax/2 && GameManager.hitLeft <= GameManager.hitMax){
                GameManager.currentXp += GameManager.xpPro;
                xpWon.Text = GameManager.currentXp.ToString();
                GD.Print("trois étoiles");
            }else if(GameManager.hitLeft > GameManager.hitMax/3 && GameManager.hitLeft <= GameManager.hitMax/2){
                GameManager.currentXp += (int) (GameManager.xpPro * 0.75);
                xpWon.Text = GameManager.currentXp.ToString();
                GD.Print("deux étoiles");
            }else{
                GameManager.currentXp += (int) (GameManager.xpPro * 0.5);
                xpWon.Text = GameManager.currentXp.ToString();
                GD.Print("une étoile : ");
            }  
        }else if(GameManager.difficulty == 3){
            if(GameManager.hitLeft > GameManager.hitMax/2 && GameManager.hitLeft <= GameManager.hitMax){
                GameManager.currentXp += GameManager.xpKiller;
                xpWon.Text = GameManager.currentXp.ToString();
                GD.Print("trois étoiles");
            }else if(GameManager.hitLeft > GameManager.hitMax/3 && GameManager.hitLeft <= GameManager.hitMax/2){
                GameManager.currentXp += (int) (GameManager.xpKiller * 0.75);
                xpWon.Text = GameManager.currentXp.ToString();
                GD.Print("deux étoiles");
            }else{
                GameManager.currentXp += (int) (GameManager.xpKiller * 0.5);
                xpWon.Text = GameManager.currentXp.ToString();
                GD.Print("une étoile : ");
            }  
        }
        this.Visible = true;
        DataManager.saveData(GameManager.currentXp.ToString());
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
