using Godot;
using System;

public class DataManager : Node
{
    public static void saveData(string level){
        Godot.Collections.Dictionary<string, string> data = new Godot.Collections.Dictionary<string, string>();
        data.Add("level", level);

        File file = new File();
        file.Open("user://saved_data.dat", File.ModeFlags.Write);
        file.StoreLine(JSON.Print(data));
        file.Close();
    }

    public static Godot.Collections.Dictionary loadData(){
        File file = new File();
        if(!file.FileExists("user://saved_data.dat")){
            GD.Print("Pas de sauvegarde !");
            return null;
        }
        file.Open("user://saved_data.dat", File.ModeFlags.Read);
        Godot.Collections.Dictionary content = (Godot.Collections.Dictionary) JSON.Parse(file.GetAsText()).Result;
        return content;
    }
}
