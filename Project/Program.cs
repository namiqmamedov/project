using Core.Constants;
using Core.Helper;
using Manage.Controller;
using System;
using System.Drawing;
using Console = Colorful.Console;

namespace Manage
{
    public class Program
    {
        static void Main()
        {
            OwnerController _ownerController = new OwnerController();
            DrugStoreController _drugStoreController = new DrugStoreController();
            DrugController _drugController = new DrugController();
            DrugGistController _drugGistController = new DrugGistController();
            AdminController _adminController = new AdminController();
                string logo = @"                            
        ___       __          _          __                _     
       /   | ____/ /___ ___  (_)___     / /   ____  ____ _(_)___ 
      / /| |/ __  / __ `__ \/ / __ \   / /   / __ \/ __ `/ / __ \
     / ___ / /_/ / / / / / / / / / /  / /___/ /_/ / /_/ / / / / /
    /_/  |_\__,_/_/ /_/ /_/_/_/ /_/  /_____/\____/\__, /_/_/ /_/ 
                                                 /____/          
                                                                                                                                                                                                           
    ";
            Console.WriteLine(logo, Color.BlueViolet);
        Authentication: var admin = _adminController.Authenticate();

            if (admin != null)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome => {admin.Username}");

                Console.WriteLine("--------------");

                while (true)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Main Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[1] Owners");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[2] Drugstores");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[3] Drugs");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[4] Druggists");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[5] Logout");

                    Console.WriteLine("--------------");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Select Number");
                    string number = Console.ReadLine();
                    int SelectedNumber;
                    bool result = int.TryParse(number, out SelectedNumber);

                    if (result)
                    {

                        if (SelectedNumber == 1)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[1] Create Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[2] Update Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[3] Delete Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[4] Get All Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[0] Main Menu");

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Select Option");
                            number = Console.ReadLine();
                            result = int.TryParse(number, out SelectedNumber);

                            if (SelectedNumber >= 0 && SelectedNumber <= 4)
                            {
                                switch (SelectedNumber)
                                {
                                    case (int)Options.CreateOwner:
                                        _ownerController.Create();
                                        break;                                      
                                    case (int)Options.UpdateOwner:
                                        _ownerController.Update();
                                        break;
                                    case (int)Options.DeleteOwner:
                                        _ownerController.Delete();
                                        break;
                                    case (int)Options.GetAllOwner:
                                        _ownerController.GetAll();
                                        break;
                                   
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number !");
                            }

                        }
                        else if (SelectedNumber == 2)
                        {
                            string logo1 = @"

        ____                        __                
       / __ \_______  ______ ______/ /_____  ________ 
      / / / / ___/ / / / __ `/ ___/ __/ __ \/ ___/ _ \
     / /_/ / /  / /_/ / /_/ (__  ) /_/ /_/ / /  /  __/
    /_____/_/   \__,_/\__, /____/\__/\____/_/   \___/ 
                     /____/                           
                  
    ";
                            Console.WriteLine(logo1, Color.BlueViolet);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[5] Create Drugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[6] Update Drugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[7] Delete Drugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[8] Get All Drugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[9] Get All Drugstores By Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[10] Sale");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[0]  Main Menu");

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Select Option");
                            number = Console.ReadLine();
                            result = int.TryParse(number, out SelectedNumber);
                            if (SelectedNumber >= 0 && SelectedNumber <= 11)
                            {
                                switch (SelectedNumber)
                                {
                                    case (int)Options.CreateDrugStore:
                                        _drugStoreController.Create();
                                        break;
                                    case (int)Options.UpdateDrugStore:
                                        _drugStoreController.Update();
                                        break;
                                    case (int)Options.DeleteDrugStore:
                                        _drugStoreController.Delete();
                                        break;
                                    case (int)Options.GetAllDrugStore:
                                        _drugStoreController.GetAll();
                                        break;
                                    case (int)Options.GetAllDrugStoresByOwner:
                                        _drugStoreController.GetAllDrugStoresByOwner();
                                        break;
                                    case (int)Options.Sale:
                                        _drugStoreController.Sale();
                                        break;                                   
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number !");

                            }

                        }
                        else if (SelectedNumber == 3)
                        {
                            string logo2 = @"                    
                           ___________
                          [___________]
                           {=========}
                         .-'         '-.
                        /               \
                       /_________________\
                       |   _  _   _      |
                       ||\(_ |_)||_)||\ ||
      ,.--.   ,.--.    ||~\_)|  || \|| \||
     // \  \ // \  \   |_________________|
     \\  \ / \\  \ /   |                 |
      `'--'   `'--'    '-----------------' 
                             
    ";
                            Console.WriteLine(logo2, Color.BlueViolet);

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[11] Create Drugs");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[12] Update Drugs");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[13] Delete Drugs");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[14] Get All Drugs");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[15] Get All Drugs By Drugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[16] Filter");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[0]  Main Menu");

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Select Option");
                            number = Console.ReadLine();
                            result = int.TryParse(number, out SelectedNumber);
                            if (SelectedNumber >= 0 && SelectedNumber <= 16)
                            {
                                switch (SelectedNumber)
                                {
                                    case (int)Options.CreateDrugs:
                                        _drugController.Create();
                                        break;
                                    case (int)Options.UpdateDrugs:
                                        _drugController.Update();
                                        break;
                                    case (int)Options.DeleteDrugs:
                                        _drugController.Delete();
                                        break;
                                    case (int)Options.GetAllDrugs:
                                        _drugController.GetAll();
                                        break;
                                    case (int)Options.GetAllDrugsByDrugStore:
                                        _drugController.GetAllDrugsByDrugStore();
                                        break;
                                    case (int)Options.Filter:
                                        _drugController.Filter();
                                        break;                                  
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number !");

                            }
                        }
                        else if (SelectedNumber == 4)
                        {
                            string logo3 = @"

        ____                         _      __ 
       / __ \_______  ______ _____ _(_)____/ /_
      / / / / ___/ / / / __ `/ __ `/ / ___/ __/
     / /_/ / /  / /_/ / /_/ / /_/ / (__  ) /_  
    /_____/_/   \__,_/\__, /\__, /_/____/\__/  
                     /____//____/              

    ";
                            Console.WriteLine(logo3, Color.BlueViolet);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[17] Create Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[18] Update Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[19] Delete Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[20] Get all druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[21] Get all druggist by drugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[0]  Main Menu");

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Select Option");
                            number = Console.ReadLine();
                            result = int.TryParse(number, out SelectedNumber);
                            if (SelectedNumber >= 0 && SelectedNumber <= 21)
                            {
                                switch (SelectedNumber)
                                {
                                    case (int)Options.CreateDrugGist:
                                        _drugGistController.Create();
                                        break;
                                    case (int)Options.UpdateDrugGist:
                                        _drugGistController.Update();
                                        break;
                                    case (int)Options.DeleteDrugGist:
                                        _drugGistController.Delete();
                                        break;
                                    case (int)Options.GetAllDrugGist:
                                        _drugGistController.GetAll();
                                        break;
                                    case (int)Options.GetAllDrugGistByDrugStore:
                                        _drugGistController.GetAllDrugGistByDrugstore();
                                        break;                                  
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number !");

                            }

                        }
                        else if (SelectedNumber == 5)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[22] Logout user");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "[0]  Main Menu");

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Select Option");
                            number = Console.ReadLine();
                            result = int.TryParse(number, out SelectedNumber);
                            if (SelectedNumber >=0 && SelectedNumber <= 22)
                            {
                                switch (SelectedNumber)
                                {
                                    case (int)Options.Logout:
                                        _adminController.Logout();
                                        break;                                   
                                }
                            }
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number!");
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Admin username or password is incorrect");
                goto Authentication;
            }

        }
    }
}

