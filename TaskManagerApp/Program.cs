
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Reflection;
using TaskManagerApp;
using Task = TaskManagerApp.Task;

class Program
{

    static void Main(string[] args)
    {
        
        string input = "";
        Object action;
        bool startApp = false;
        bool isAdmin = false;
        User user;

        TaskManager taskManager = new TaskManager();


        //Selects Name. If name is not Admin then it continues to running the User Interface
        while (!startApp)
        {
            Console.Write("Enter Name: ");
            input = Console.ReadLine();
            if (input != null && input != "Admin")
            {
                startApp = true;
            } else
            {
                if (input != null && input == "Admin")
                {
                    Console.Write("Enter Password: ");
                    input = Console.ReadLine();
                    if (input != null && input == "12345")
                    {
                        Console.WriteLine("Admin Welcome");
                        isAdmin = true;
                    } else
                    {
                        Console.WriteLine("Wrong Password");
                    }
                }
            }

        }


        //User Setup. If User ID exists, it retrieves the original Users Task.
        if (isAdmin == false)
        {
            UserManager userManager = new UserManager();
            string userID;
            Console.WriteLine("Enter ID (if you have one): ");
            string input_id = Console.ReadLine();
            input_id = ((int) errorChecking(input_id, "is a Number")).ToString();
            if (userManager.userExists(input_id))
            {
                Console.WriteLine("User Exists, retrieving correct Name...");
                userID = input_id;
                user = userManager.getUser(userID);
               

                taskManager.setUserFilePath(userID);
                taskManager.JsonFileReader();

            } else
            {
                userID = input_id;
                taskManager.setUserFilePath(userID);
                taskManager.JsonFileReader();
                user = new User(input, userID);
                userManager.addUser(user);


            }
            

            Console.WriteLine($"Hello {user.getName()} with ID: {user.getID()}");
        } else
        {
            //Admin setup for Admin Interface
        }





        


        bool exitApp = false;

        while (!exitApp)
        {
            

        //page_user_welcome 




            showMenu("page_user_welcome");



        //-------------| Checks whether user input is a valid text |--------------------------------------|
            input = Console.ReadLine();

            action = (int) errorChecking(input, "choose 1 - 6");
        //------------------------------------------------------------------------------------------------|

            //used to escape out of every while loop
            bool confirm = false;
            bool tasksIsEmpty = taskManager.dictionaryIsEmpty();


        //-------------| User Option - Add, Edit, Delete, View Tasks, Exit App (START) |------------------|

            switch ((int) action)
            {
            //-------------| Add Task (START) |-----------------------------------------------------------|
                case 1:
                    
                    
                    Task task = new Task();
                    
                    while (!confirm)
                    {

                        
                        showMenu("page_add & page_edit");



                    //-----------| Checks whether user input is a valid text | ---------------------------|
                        input = Console.ReadLine();

                        action = (int) errorChecking(input, "choose 1 - 6"); 
                    //------------------------------------------------------------------------------------|
                        

                        switch ((int) action)
                        {
                        //Choose Title
                            case 1:
                                Console.WriteLine("| Choose Title |");
                                input = Console.ReadLine();
                                task.setTitle(input);
                                Console.WriteLine($"Title Chosen");

                                break;

                        //Choose Description
                            case 2:
                                Console.WriteLine("| Choose Description |");
                                input = Console.ReadLine();
                                task.setDescription(input);
                                Console.WriteLine($"Description Chosen");


                                break;

                        //Choose Priority
                            case 3:
                                Console.WriteLine("| Choose Priority |");
                                input = Console.ReadLine();
                                task.setPriority(input);
                                Console.WriteLine($"Priority Chosen");

                                break;

                        //Choose DueDate
                            case 4:
                                Console.WriteLine("| Choose Due Date |");
                                input = Console.ReadLine();
                                task.setDueDate(input);
                                Console.WriteLine($"DueDate Chosen");

                                break;

                        //Choose Confirm 
                            case 5:
                                Console.Write("Confirm Task? Enter Y/N: ");
                                input = Console.ReadLine();
                                Console.WriteLine();

                                action = (string) errorChecking(input, "Confirm Y/N");
                                if ((string) action == "Y")
                                {
                                    //Console.WriteLine($"Chose Yes!");
                                    Console.WriteLine($"Adding task...");

                                    string taskID = GenerateRandomID();
                                    task.setTaskID(taskID);

                                    taskManager.addTasks(task);

                                    Console.WriteLine($"Task Added!");
                                    confirm = true;
                                }
                                //Console.WriteLine($"Editing Attri...");
                                break;

                            case 6:
                                Console.Write("Are you sure you want to Return? (The task will not be saved) Enter Y/N: ");
                                input = Console.ReadLine();
                                action = (string) errorChecking(input, "Confirm Y/N");
                                if (action == "Y")
                                {
                                    Console.WriteLine("Returning To Main Menu...");
                                    confirm = true;
                                }


                                break;
                        }
                        Console.WriteLine();
                    }


                    //taskManager.viewTasks();

                    break;
            //-------------| Add Task (END) |-------------------------------------------------------------|



            //-------------| Edit Task (START) |----------------------------------------------------------|
                case 2:
                    if (tasksIsEmpty)
                    {
                        Console.WriteLine("You don't have any Tasks, returning to Main Menu...");
                        break;
                    }

                    Console.Write("Enter Task ID: ");
                    input = Console.ReadLine();
                    action = (Task)errorChecking(input, "choose TaskID");
                    Console.WriteLine($"All ok we got {action}\n");
                    Task taskToEdit = (Task) action;
                    taskManager.viewTaskSingle(taskToEdit);

                    while (!confirm)
                    {
                        showMenu("page_add & page_edit");

                        //-----------| Checks whether user input is a valid text | ---------------------------|
                        input = Console.ReadLine();

                        action = (int)errorChecking(input, "choose 1 - 5");

                        Console.WriteLine("FTANEI MEXRI EDW KAI VGAZEI: " + action);
                        //------------------------------------------------------------------------------------|

                        switch ((int)action)
                        {
                            //Choose Title
                            case 1:
                                Console.WriteLine("Choose Title...");
                                input = Console.ReadLine();
                                taskToEdit.setTitle(input);
                                Console.WriteLine($"Chose {input}");

                                break;

                            //Choose Description
                            case 2:
                                Console.WriteLine("Choose Description...");
                                input = Console.ReadLine();
                                taskToEdit.setDescription(input);
                                Console.WriteLine($"Chose {input}");


                                break;

                            //Choose Priority
                            case 3:
                                Console.WriteLine("Choose Priority...");
                                input = Console.ReadLine();
                                taskToEdit.setPriority(input);
                                Console.WriteLine($"Chose {input}");

                                break;

                            //Choose DueDate
                            case 4:
                                Console.WriteLine("Choose Due Date...");
                                input = Console.ReadLine();
                                taskToEdit.setDueDate(input);
                                Console.WriteLine($"Chose {input}");

                                break;

                            //Choose Confirm 
                            case 5:
                                Console.Write("Confirm Task? Enter Y/N: ");
                                input = Console.ReadLine();

                                Console.WriteLine("\n");

                                action = (string)errorChecking(input, "Confirm Y/N");
                                if ((string)action == "Y")
                                {
                                    Console.WriteLine($"Chose Yes!");
                                    Console.WriteLine($"Editing task...");

                                    taskManager.editTask(taskToEdit);

                                    confirm = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Chose No...");
                                }
                                break;

                        }
                    }

                    


                    break;
            //-------------| Edit Task (END) |------------------------------------------------------------|




            //-------------| Delete Task (START) |--------------------------------------------------------|
                case 3:

                    if (tasksIsEmpty)
                    {
                        Console.WriteLine("You don't have any Tasks, returning to Main Menu...");
                        break;
                    }

                    Console.Write("Enter Task ID: ");

                    //-------------| Checks whether user input is a valid text |--------------------------------------|
                    input = Console.ReadLine();

                    action = (Task) errorChecking(input, "choose TaskID");

                    //------------------------------------------------------------------------------------------------|

                    Task taskToDelete = (Task) action;

                    taskManager.viewTaskSingle(taskToDelete);

                    Console.Write($"Confirm Deletion of Task with ID {taskToDelete.getTaskID()}? (Y/N): ");

                    input = Console.ReadLine();

                    action = (string) errorChecking(input, "Confirm Y/N");

                    Console.WriteLine();


                    if ((string) action == "Y")
                    {
                        taskManager.deleteTask(taskToDelete);
                        Console.WriteLine("Task deleted successfully!");
                    } 
                    else
                    {
                        Console.WriteLine("Returning to Main Menu...");
                    }

                    break;
            //-------------| Delete Task (END) |----------------------------------------------------------|



            //-------------| View Tasks (START) |---------------------------------------------------------|
                case 4:

                    bool isEmpty = taskManager.dictionaryIsEmpty();
                    if (isEmpty)
                    {
                        Console.WriteLine("You don't have any Tasks, returning to Main Menu...");
                        break;
                    }

                    while (!confirm)
                    {

                        showMenu("page_view_tasks");

                        //-----------| Checks whether user input is a valid text | ---------------------------|
                        input = Console.ReadLine();

                        action = (int)errorChecking(input, "choose 1 - 3");

                        Console.WriteLine();
                        //------------------------------------------------------------------------------------|

                        Console.Write("Would you like to return to the Main Menu? Enter Y/N: ");

                        //-----------| Checks whether user input is a valid text | ---------------------------|
                        input = Console.ReadLine();

                        input = (string)errorChecking(input, "Confirm Y/N");

                        Console.WriteLine();
                        //------------------------------------------------------------------------------------|
                        if (input == "Y")
                        {
                            Console.WriteLine("Returning to Main Menu...");
                            confirm = true;

                        }
                        break;
                    }

                    




                    break;
            //-------------| View Tasks (END) |-----------------------------------------------------------|




            //-------------| Exit App (START) |-----------------------------------------------------------|
                case 5:

                    Console.Write("Exit App? Enter Y/N: ");
                    input = Console.ReadLine();

                    Console.WriteLine("\n");

                    action = (string) errorChecking(input, "Confirm Y/N");

                    if ((string) action == "Y")
                    {
                        Console.WriteLine($"Exiting App...");
                        exitApp = true;
                    }
                    break;
            //-------------| Exit App (END) |-------------------------------------------------------------|



            }

        //-------------| User Option - Add, Edit, Delete, View Tasks, Exit App (END) |--------------------|






        }

        //Responsible for the UI of the console App. 
        void showMenu(string page)
        {
            switch (page)
            {
                case "page_user_welcome":

                    Console.WriteLine("|-------------------------------------------------------------------------------|");
                    Console.WriteLine("  What would you like to do today? (Enter a number between 1 and 5)");

                    Console.WriteLine("  1. Add Task");
                    Console.WriteLine("  2. Edit Task");
                    Console.WriteLine("  3. Delete Task");
                    Console.WriteLine("  4. View Tasks");
                    Console.WriteLine("  5. Exit App");
                    Console.WriteLine("|-------------------------------------------------------------------------------|");

                    Console.Write("Select Action: ");
                    break;

                case "page_add & page_edit":
                    Console.WriteLine("|-------------------------------------------------------------------------------|");
                    Console.WriteLine("  Edit Task attribute...");

                    Console.WriteLine("  1. Title");
                    Console.WriteLine("  2. Description");
                    Console.WriteLine("  3. Priority");
                    Console.WriteLine("  4. Due Date");
                    Console.WriteLine("  5. Confirm Task");
                    Console.WriteLine("  6. Return to Main Menu");
                    Console.WriteLine("|-------------------------------------------------------------------------------|");

                    Console.Write("Select Action: ");


                    break;

                case "page_view_tasks":
                    
                    Console.WriteLine("These are your Tasks!");
                    Console.WriteLine("|-------------------------------------------------------------------------------|");
                    taskManager.viewTasks();
                    Console.WriteLine("|-------------------------------------------------------------------------------|");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Edit Task");
                    Console.WriteLine("2. Delete Task");
                    Console.WriteLine("3. Return to Main Menu");
                    Console.WriteLine();
                    Console.Write("Select Action: ");




                    break;

                case "Enter Task ID":
                    
                    break;

            }
        }


        //Checks and Handles incorrect input from the User
        Object errorChecking(string input, string case_model)
        {
            int output;
            switch (case_model)
            {
                //Loops into number selection until a valid number is selected
                case "choose 1 - 6":

                    while (!Int32.TryParse(input, out output) || (output > 6 || output < 1))
                    {
                        Console.Write($"Please Enter a Number between 1 - 6: ");
                        input = Console.ReadLine();
                    }
                    Console.WriteLine();
                    return output;

                case "Confirm Y/N":
                    while (!(input == "Y" || input == "N"))
                    {
                        Console.Write("Please Enter only Y or N: ");
                        input = Console.ReadLine();


                    }
                    Console.WriteLine();
                    return input;

                case "choose 1 - 3":
                    while (!Int32.TryParse(input, out output) || (output > 3 || output < 1))
                    {
                        Console.WriteLine($"Please Enter a Number between 1 - 3: ");
                        input = Console.ReadLine();

                    }
                    Console.WriteLine();
                    return output;

                case "is a Number":
                    while (!Int32.TryParse(input, out output) || output < 0)
                    {
                        Console.Write($"Please enter a Number: ");
                        input = Console.ReadLine();
                    }
                    Console.WriteLine();
                    return output;

                case "choose TaskID":

                    Task task = taskManager.getTask(input);
                    while(task == null)
                    {
                        Console.Write("The TaskID doesn't exist, please enter a valid TaskID: ");
                        input = Console.ReadLine();
                        task = taskManager.getTask(input);
                        
                    }
                    Console.WriteLine();
                    return task;

                




                default:
                    return 0;
            }



        }

        //Creates a Random 6 digit ID for Tasks
        static string GenerateRandomID()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 1000000); // Generates a number between 100000 and 999999
            return randomNumber.ToString();
        }


        //Scrapted Function
        static int retrieveIDCounter()
        {
            string filePath = "counter.txt";
            int counter = 0;

            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                if (int.TryParse(content, out int savedCounter))
                {
                    counter = savedCounter;
                }
            }
            return counter;

        }


        //Scrapted Function
        static void updateIDCounter(int counter)
        {
            string filePath = "counter.txt";
            /*
            

            // Check if the file exists, and if so, read the counter value from it
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                if (int.TryParse(content, out int savedCounter))
                {
                    counter = savedCounter;
                }
            }*/

            File.WriteAllText(filePath, counter.ToString());

        }


    }

    
}