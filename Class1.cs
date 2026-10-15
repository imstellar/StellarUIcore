namespace StellarUIcore
{
    /// <summary>
    /// Custom-built codebase which stores user interface methods used within any program utilising console output.
    /// StellarUIcore remains the property of Enrikas Lukosevicius and is maintained for the purposes of easier development with console-based applications.
    /// </summary>
    public abstract class UI
    {

        /// <summary>
        /// Mut be implemented by the project the class is referenced within.
        /// Displays or restores static elements such as labels, headings or static elements based on the program stage.
        /// Should be used when starting the program loop or after clearing the console completely.
        /// </summary>
        public abstract void Initialise();

        /// <summary>
        /// Clears any lines specified in the parameters.
        /// </summary>
        /// <param name="lines">The rows to clear</param>
        public static void ClearLine(params int[] lines)
        {
            foreach (int line in lines)
            {
                Console.SetCursorPosition(4, line);
                Console.Write("                                                                                                                                                                                      ");
            }
        }

        /// <summary>
        /// Draws text over existing text in a specific line with optional styling and cursor placement 
        /// after the method is complete.
        /// </summary>
        /// <param name="row">The row to draw over.</param>
        /// <param name="value">The string or text to write to the specified row.</param>
        /// <param name="args">First argument (0-3) (error, warning, heading, important) - determines text style of the text, Second Argument (row) - to set the cursor after writing.</param>
        public static void DrawOverLine(int row, string value, params int[] args)
        {
            ClearLine(row);
            Console.SetCursorPosition(4, row);
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case 0:
                        // Error style
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 1:
                        // Warning style
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 2:
                        // Heading style
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        // Prompt style
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                }
            }
            Console.Write(value);
            Console.ResetColor();
            if (args.Length > 1) Console.SetCursorPosition(4, args[1]);
        }

        /// <summary>   
        /// Allows the user to input something, clearing the input row after.
        /// </summary>
        /// <param name="row">The row to set the cursor position to before getting user input.</param>
        /// <param name="args">One possible argument, the position counting from the left to set the cursor to before getting user input.</param>
        /// <returns>The user input.</returns>
        public static string ReadLineThenClear(int row, params int[] args)
        {
            if (args.Length > 0) Console.SetCursorPosition(args[0], row);
            else Console.SetCursorPosition(4, row);
            string? input = Console.ReadLine();
            ClearLine(row);
            return input!;
        }

        /// <summary>
        /// Similar to DrawOverLine, draws the specified text to column 32 - specifically for statistics display.
        /// </summary>
        /// <param name="row">The row to draw the statistic to.</param>
        /// <param name="value">The string or statistic to write.</param>
        public static void DrawStatistics(int row, string value)
        {
            Console.SetCursorPosition(32, row);
            Console.Write(value);
        }

        /// <summary>
        /// Displays a notification with styling based on the severity of the notification.
        /// </summary>
        /// <param name="severity">"update", "warning" or "debug", otherwise the style with be error.</param>
        /// <param name="message">The message or notification to write.</param>
        /// <param name="row">The row to display the message or notification in.</param>
        public static void DrawNotification(string severity, string message, int row)
        {
            ClearLine(row);
            Console.SetCursorPosition(4, row);
            if (severity == "update")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (severity == "warning")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (severity == "debug")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
