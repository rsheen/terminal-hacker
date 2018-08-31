using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

	void ShowMainMenu(){
        currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("You need info to solve a case.\nWhere would you like to hack into?\n\nPress 1 for the library\nPress 2 for city hall\nPress 3 for S.H.I.E.L.D.");
	}

	void OnUserInput(string input)
    {
        if (input == "menu") //we can always return back to main menu
        {
            ShowMainMenu();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);   
        }

    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            Start();
        }
        else if (input == "2")
        {
            level = 2;
            Start();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level, Mr. Bond!");

        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }
}
