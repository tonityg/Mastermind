using Godot;
using System;

public class Init : Node
{
    public override void _Ready()
    {
        Godot.Collections.Dictionary data = DataManager.loadData();
        if(data != null){
            GameManager.currentXp = data["level"].ToString().ToInt();
            GD.Print(GameManager.currentXp);
        }else{
            GD.Print("Chargement impossible !");
        }
        
    }

}
