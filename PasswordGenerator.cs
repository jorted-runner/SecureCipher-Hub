using System;
using System.Collections.Generic;

public class PasswordGenerator
{
    private int _length;
    private List<char> _specialSymbolList = new List<char>() { '!', '(', ')', '-', '.', '?', '[', ']', '_', '\'', '~', '@', '#', '$', '%', '&', '*', '+' };
    private List<char> _numbersList = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
    private List<char> _lowerLettersList = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    private List<char> _capitalLettersList = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

    public PasswordGenerator()
    {
        _length = SetLength();
    }
    private int SetLength () {
        return int.Parse(UserInterface.GetUserInput("How many characters does the password need to be? "));

    }

    public string GeneratePassword()
    {
        Random _random = new Random();
        List<char> _tempPassword = new List<char>();
        int i = 0;
        while (i < _length)
        {
            int randCharacterList = _random.Next(0, 6);
            switch (randCharacterList)
            {
                case 0:
                    _tempPassword.Add(ChooseCharacter(_specialSymbolList));
                    break;
                case 1:
                    _tempPassword.Add(ChooseCharacter(_numbersList));
                    break;
                case 2:
                    _tempPassword.Add(ChooseCharacter(_lowerLettersList));
                    break;
                case 3:
                    _tempPassword.Add(ChooseCharacter(_capitalLettersList));
                    break;
                case 4:
                    _tempPassword.Add(ChooseCharacter(_lowerLettersList));
                    break;
                case 5:
                    _tempPassword.Add(ChooseCharacter(_capitalLettersList));
                    break;
            }
            i++;
        }

        Shuffle(_tempPassword);
        string shuffledString = new string(_tempPassword.ToArray());
        Console.WriteLine($"Password: {shuffledString}");
        return shuffledString;
    }

    private char ChooseCharacter(List<char> values)
    {
        Random _random = new Random();
        int characterLocation = _random.Next(0, values.Count);
        return values[characterLocation];
    }

    private void Shuffle<T>(List<T> list)
    {
        Random random = new Random();
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
