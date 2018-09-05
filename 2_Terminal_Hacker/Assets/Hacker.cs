using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game configuration data
    string[] level1Passwords = { "books", "phone", "homework", "aisle", "borrow" };
    string[] level2Passwords = { "security", "pension", "vote", "budget", "mayor" };
    string[] level3Passwords = { "benevolence", "clandestine", "undercover", "rebellious", "teamwork" };

    //Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
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
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "007");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        if(level == 1 || level == 2 || level == 3)
        {
            Terminal.WriteLine("Enter your password, hint:" + password.Anagram());
        }
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                //individual WriteLine because of 007 Bond case
                password = level1Passwords[Random.Range(0, 5)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, 5)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, 5)];
                break;
            case 007:
                Terminal.WriteLine("Please select a level, Mr. Bond!");
                Invoke("ShowMainMenu", 2);
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
 
      ____________ 
     /           //    
    /           //
   /           // 
  /           //
 /_________  //
(___________(/                
"
                                  );

                break;
            case 2:
                Terminal.WriteLine("Have a flag...");
                Terminal.WriteLine(@"
         _____________
      / /____________/
     / /____________/
    / /____________/
   / /____________/
  / /
 / /
/_/
             
"
                                  );
                break;
            case 3:
                Terminal.WriteLine("Have an eagle...");
                Terminal.WriteLine(@"
        ___       _
\      /   \     / \
 \    /   --    /  /
  \  /    \    /  /
   \/      \__/  / 
                /
\__          _ /
   \_ _     /
       \___/
"
                                  );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
