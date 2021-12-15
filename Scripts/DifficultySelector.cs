using Godot;
using System;

public class DifficultySelector : Control
{
    [Export] int noviceDifficulty = 4;
    [Export] int proDifficulty = 5;
    [Export] int killerDifficulty = 6;

    [Export] int hitNovice = 12;
    [Export] int hitPro = 15;
    [Export] int hitKiller = 20;

    void generateCombination(){
        int[] generateComputerCombination = new int[GameManager.maxValuesAccepted];
        RandomNumberGenerator random = new RandomNumberGenerator();
        random.Randomize();
        for (int i = 0; i < generateComputerCombination.Length; i++)
        {
            generateComputerCombination[i] =  random.RandiRange(1, 8);
            GD.Print(generateComputerCombination[i]);
        }
        GameManager.combinationGenerated = generateComputerCombination;
    }

    void changeDifficulty(int difficulty){
        GameManager.difficulty = difficulty;
        switch(GameManager.difficulty){
            case 1:
                GameManager.maxValuesAccepted = noviceDifficulty;
                GameManager.hitLeft = hitNovice;
                GameManager.hitMax = hitNovice;
                break;
            case 2:
                GameManager.maxValuesAccepted = proDifficulty;
                GameManager.hitLeft = hitPro;
                GameManager.hitMax = hitPro;
                break;
            case 3:
                GameManager.maxValuesAccepted = killerDifficulty;
                GameManager.hitLeft = hitKiller;
                GameManager.hitMax = hitKiller;
                break;
            default:
                GameManager.maxValuesAccepted = noviceDifficulty;
                GameManager.hitLeft = hitNovice;
                GameManager.hitMax = hitNovice;
                break;
        }
        generateCombination();

        GetTree().ChangeScene("res://Levels/Game.tscn");
    }

    void _on_Novice_pressed(){
        changeDifficulty(1);
    }

    void _on_Pro_pressed(){
        changeDifficulty(2);
    }

    void _on_Killer_pressed(){
        changeDifficulty(3);
    }
}
