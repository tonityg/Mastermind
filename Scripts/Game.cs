using Godot;
using System;

public class Game : Control
{
    Label numbersEntry;

    int maxValuesAccepted;

    [Export] int noviceDifficulty = 4;
    [Export] int proDifficulty = 5;
    [Export] int killerDifficulty = 6;

    public override void _Ready()
    {
        numbersEntry = GetNode<Label>("NumEntry/Label");

        switch(GameManager.difficulty){
            case 1:
                maxValuesAccepted = noviceDifficulty;
                break;
            case 2:
                maxValuesAccepted = proDifficulty;
                break;
            case 3:
                maxValuesAccepted = killerDifficulty;
                break;
            default:
                maxValuesAccepted = noviceDifficulty;
                break;
        }
    }

    void addNumbersToEntry(int number){
        if(numbersEntry.Text.Length >= maxValuesAccepted)
            return;

        numbersEntry.Text = numbersEntry.Text + number;
    }

    void _on_Delete_pressed(){
        GD.Print("Delete pressed");

        char[] newNumbersEntryList = new char[numbersEntry.Text.Length - 1];
        for(int i = 0 ; i < numbersEntry.Text.Length - 1 ; i++){
            newNumbersEntryList[i] = numbersEntry.Text[i];
        }

        numbersEntry.Text = "";
        foreach(char number in newNumbersEntryList){
            numbersEntry.Text = numbersEntry.Text + number;
        }
        
        // numbersEntry = numbersEntry.Text - lastValue;
    }

    void _on_Confirm_pressed(){
        GD.Print("Confirm pressed");
        if(numbersEntry.Text.Length == maxValuesAccepted){
            GD.Print("Number of value acceptable");
            
            int[] userCombination = new int[maxValuesAccepted];
            for(int i = 0; i < maxValuesAccepted; i++)
            {
                GD.Print(i);
                userCombination[i] = numbersEntry.Text[i];
            }

            foreach(int number in userCombination){
                GD.Print("user : " + number);
            }

            foreach(int number in GameManager.combinationGenerated){
                GD.Print("computer : " + number);
            }
            numbersEntry.Text = "";
        }
    }

    void _on_1_pressed(){
        addNumbersToEntry(1);
    }

    void _on_2_pressed(){
        addNumbersToEntry(2);
    }

    void _on_3_pressed(){
        addNumbersToEntry(3);
    }

    void _on_4_pressed(){
        addNumbersToEntry(4);
    }

    void _on_5_pressed(){
        addNumbersToEntry(5);
    }

    void _on_6_pressed(){
        addNumbersToEntry(6);
    }

    void _on_7_pressed(){
        addNumbersToEntry(7);
    }

    void _on_8_pressed(){
        addNumbersToEntry(8);
    }

    void _on_9_pressed(){
        addNumbersToEntry(9);
    }
}
