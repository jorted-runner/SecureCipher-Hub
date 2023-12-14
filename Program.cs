using System;

class Program
{
    static void Main(string[] args)
    {   
        bool loggedIn = false;
        UserInterface _userInterface = new UserInterface();
        while (loggedIn == false) {
            loggedIn = _userInterface.DisplayLoginMenu();
        }
        bool running = true;
        if (loggedIn) {
            while (running) {
                running = _userInterface.DisplayMainMenu();
            }
        }
    }
}