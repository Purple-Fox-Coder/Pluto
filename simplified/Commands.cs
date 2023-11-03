namespace Pluto
{
    /**
     * By: Anna Robinson
     * 
     * This is a simplified version of the Commands class.
     * 
     * To use it you will have to directly add in your commands and hard code them in,
     * the modular version will allow you to only have to create the functions and then add any
     * names, aliases and descriptions that you want.
     * 
     * To add a command to this you will need to
     * add the case in the RunCommand() function's switch statement,
     * in the help() function's switch statement, and create the
     * function that gets run when the command is activated.
     * 
     * You will then need to add it to the full help message's string.
     * 
     * command - the command executed by the user
     * args - any arguments passed in for the commands, I.E. for the help command:
     *      this would be the command you want help on.
     * input - the raw input from Console.Readline()
     * 
     * RunCommand() - This function runs a specific command
     * RunCommands() - this command sets up the loop and will check
     *              for what commands need to be run.
     * ParseUserCommandInput() - Parses the input the user puts into
     *                  Console.Readline() 
     * Help() - the default help command
     */
    public static class Commands
    {
        /// <summary>
        /// runs a specific command
        /// </summary>
        /// <param name="command">the command executed by the user</param>
        /// <param name="args">any arguments passed in for the commands, I.E. for the help command: this would be the command you want help on.</param>
        private static void RunCommand(string command, string[] args)
        {
            /**
             * Based on what command was entered run the command
             * and pass in arguments, you may also check if too many
             * arguments for that command were passed in here.
             * 
             * If no valid command was passed in, run the help command and
             * inform the user that their command is invalid.
             */
            switch (command)
            {
                default:
                    Console.WriteLine("Invalid command!");
                    Help(args);
                    break;
            }
        }

        /// <summary>
        /// this command sets up the loop and will check for what commands need to be run.
        /// </summary>
        public static void RunCommands()
        {
            // initialize variables
            string command = ""; // the parsed command
            List<string> args = new List<string>(); // arguments for the command
            string? userInput = null; // the raw input

            /**
             * The command loop goes as such:
             * 1. Get console input, make sure it is valid
             * 2. If it is valid then parse it and store the information in the respective
             *    variables
             * 3. Run the command with the information from the user's input.
             */
            while (command != "quit")
            {
                // try catch for user input
                try
                {
                    Console.WriteLine("Please enter a command");
                    userInput = Console.ReadLine();

                    if (userInput == null)
                    {
                        Console.WriteLine("Invalid command");
                        continue;
                    }

                    ParseUserCommandInput(userInput, ref command, ref args);

                    // check if there was a problem running the command while running it.
                    try
                    {
                        RunCommand(command, args.ToArray());
                    }
                    catch
                    {
                        Console.WriteLine("There was an issue running your command");
                    }
                }
                catch
                {
                    Console.WriteLine("Your command was invalid.");
                }
            }
        }

        /// <summary>
        /// parses the input from the user into usable command information
        /// </summary>
        /// <param name="input">The user's input, expected to be something like: help quit</param>
        /// <param name="command">the command executed by the user</param>
        /// <param name="args">any arguments passed in for the commands, I.E. for the help command: this would be the command you want help on.</param>
        private static void ParseUserCommandInput(string input, ref string command, ref List<string> args)
        {
            /**
             * Get the input, remove any whitespace and set it to lowercase.
             * Then we need to seperate out the command and arguements, so we
             * split it by spaces.  The command should be the first thing in
             * the array, and any arguments should come after.  Any empty strings
             * that are left are not arguments and should just be ignored.
             */

            string[] parsedInput = input.Trim().ToLower().Split(' ');
            command = parsedInput[0];
            for (int i = 1; i <  parsedInput.Length; i++)
            {
                if (parsedInput[i].Trim() == "") continue;
                args.Add(parsedInput[i].Trim());
            }
        }

        /// <summary>
        /// basic help command
        /// </summary>
        /// <param name="args">the command the user wanted help with</param>
        private static void Help(string[] args)
        {
            const string DEFAULT_HELP_MESSAGE = "List Out Commands";

            if (args.Length == 0) // no arguments, send the default help message.
            {
                Console.WriteLine(DEFAULT_HELP_MESSAGE);
                return;
            }

            /**
             * Help only takes one argument, so we only worry about the first one.
             * go over each possible command the user could be asking for help on,
             * and any potential alias, then write the appropriate message.
             * If the argument does not correspond to an existing command simply
             * send the default help message.
             */
            switch (args[0])
            {
                case "help":
                    Console.WriteLine("Help - Provides information about commands");
                    return;
                case "quit":
                    Console.WriteLine("Quit - Quits the program");
                    return;
                default:
                    Console.WriteLine(DEFAULT_HELP_MESSAGE);
                    return;
            }
        }
    }
}
