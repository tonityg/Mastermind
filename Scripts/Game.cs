using Godot;
using System;

public class Game : Control
{
    Label numbersEntry;
    Label tipsSymbols;
    Label hitRemain;
    Label answer;
    Label xpWon;

    [Signal] public delegate void victory(); 
    [Signal] public delegate void lose(); 

    public override void _Ready()
    {
        numbersEntry = GetNode<Label>("NumEntry/Label");
        tipsSymbols = GetNode<Label>("Tips");
        hitRemain = GetNode<Label>("Remain");
        answer = GetNode<Label>("Answer");

        foreach (int number in GameManager.combinationGenerated)
        {
            answer.Text = answer.Text + number;
        }

        hitRemain.Text = GameManager.hitLeft + " hits remaining";
    }

    void addNumbersToEntry(int number){
        if(numbersEntry.Text.Length >= GameManager.maxValuesAccepted)
            return;

        numbersEntry.Text = numbersEntry.Text + number;
    }

    char[] symbolTip(int[] user, int[] computer){
        char[] symbols = new char[GameManager.maxValuesAccepted];

        int[] userList = new int[user.Length];
        for (int i = 0; i < userList.Length; i++)
        {
            userList[i] = user[i];
        }

        int[] computerList = new int[computer.Length];
        for (int i = 0; i < computerList.Length; i++)
        {
            computerList[i] = computer[i];
        }

        int hashtag = 0;
        int nbo = 0;
        for (int i = 0; i < computerList.Length; i++)
        {
            GD.Print("computer : " + computerList[i]);
            for(int j = 0; j < userList.Length; j++){
                GD.Print("user : " + userList[j]);
                if(computerList[i] == userList[j] && i == j){
                    userList[i] = -1;
                    computerList[j] = -2;
                    hashtag++;
                    break;
                }else if(userList[i] == computerList[j] && userList[i] != computerList[i] && userList[j] != computerList[j]){
                    userList[i] = -3;
                    computerList[j] = -4;
                    nbo++;
                }
            }
        }
        int positionFilled = symbols.Length;

        for (int i = 0; i < hashtag; i++)
        {
            symbols[i] = '#';
            positionFilled--;
        }

        for (int i = 0; i < nbo; i++)
        {
            symbols[i+hashtag] = 'o';
            positionFilled--;
        }

        for (int i = 0; i < symbols.Length - (hashtag + nbo); i++)
        {
            symbols[i+hashtag+nbo] = '/';
        }

        return symbols;
    }

    void isValidCombination(int[] user, int[] computer){
        GD.Print("Confirm pressed");        
        
        for(int i = 0; i < numbersEntry.Text.Length; i++)
        {
            GD.Print((int) Char.GetNumericValue(numbersEntry.Text[i]));
            user[i] = (int) Char.GetNumericValue(numbersEntry.Text[i]);
        }

        for (int i = 0; i < computer.Length; i++)
        {
            if(GameManager.combinationGenerated[i] != user[i]){
                GD.Print("Faux !");
                numbersEntry.Text = "";
                return;
            }
        }

        GD.Print("Les combinaisons sont égaux !");
        EmitSignal("victory");
    }

    void _on_Delete_pressed(){
        GD.Print("Delete pressed");
        if(numbersEntry.Text.Length != 0){
            char[] newNumbersEntryList = new char[numbersEntry.Text.Length - 1];
            for(int i = 0 ; i < numbersEntry.Text.Length - 1 ; i++){
                newNumbersEntryList[i] = numbersEntry.Text[i];
            }

            numbersEntry.Text = "";
            foreach(char number in newNumbersEntryList){
                numbersEntry.Text = numbersEntry.Text + number;
            }
        }
        
    }

    void _on_Confirm_pressed(){
        if(numbersEntry.Text.Length == GameManager.maxValuesAccepted){
            GameManager.hitLeft--;
            if(GameManager.hitLeft > 0){
                int[] userCombination = new int[numbersEntry.Text.Length];
                for (int i = 0; i < userCombination.Length; i++)
                {
                    userCombination[i] = (int) Char.GetNumericValue(numbersEntry.Text[i]);
                    GD.Print(userCombination[i]);
                }

                isValidCombination(userCombination, GameManager.combinationGenerated);
                char[] symbols = symbolTip(userCombination, GameManager.combinationGenerated);
                tipsSymbols.Text = "";
                foreach (char symbol in symbols)
                {
                    tipsSymbols.Text = tipsSymbols.Text + symbol;
                }

                hitRemain.Text = GameManager.hitLeft + " hits remaining";
            }else{
                EmitSignal("lose");
            }
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
