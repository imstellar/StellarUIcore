namespace StellarUIcore
{
    /// <summary>
    /// Custom-built codebase which stores user interface methods used within any program utilising console output.
    /// StellarUIcore remains the property of Enrikas Lukosevicius and is maintained for the purposes of easier development with console-based applications.
    /// </summary>
    public static class UI
    {
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
        /// <param name="col">The column to draw over, 4 is recommended for a more sleek design.</param>
        /// <param name="value">The string or text to write to the specified row.</param>
        /// <param name="args">First color represents text, second represents background</param>
        public static void DrawOverLine(int row, int col, string value, params ConsoleColor[] args)
        {
            ClearLine(row);
            Console.SetCursorPosition(col, row);
            if (args.Length > 0)
            {
                Console.ForegroundColor = args[0];
                if (args.Length > 1)
                {
                    Console.BackgroundColor = args[1];
                }
            }
            Console.Write(value);
            Console.ResetColor();
            Console.SetCursorPosition(col, row+2);
        }

        /// <summary>   
        /// Allows the user to input something, clearing the input row after.
        /// </summary>
        /// <param name="row">The row to set the cursor position to before getting user input.</param>
        /// <param name="col">The column to set the cursor position to before getting user input, 4 is recommended for a more sleek design.</param>
        /// <returns>The user input.</returns>
        public static string ReadLineThenClear(int row, int col)
        {
            Console.SetCursorPosition(col, row);
            string? input = Console.ReadLine();
            ClearLine(row);
            return input!;
        }

        /// <summary>
        /// Displays a notification with styling based on the severity of the notification.
        /// </summary>
        /// <param name="row">The row to display the message or notification from.</param>
        /// <param name="col">The column to display the message or notification from, 4 is recommended for a more sleek design.</param>
        /// <param name="severity">"update", "warning" or "debug", other values will default to error.</param>
        /// <param name="message">The message or notification to write.</param>
        public static void DrawNotification(int row, int col, string severity, string message)
        {
            ClearLine(row);
            Console.SetCursorPosition(col, row);
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
