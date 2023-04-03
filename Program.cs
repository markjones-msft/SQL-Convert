/*
This code reads in SQL code from the console, prompts the user to enter the code and then uses the OpenAI API to convert it to TSQL.

It starts by creating a StringBuilder object to accumulate the SQL code entered by the user. 
It then enters a loop where it reads in lines of input from the console until the user enters a blank line. 
Each line of input is added to the StringBuilder object with AppendLine.

After the input is read in, it creates a Prompt string that includes the SQL code entered by the user, 
and then creates an instance of the OpenAIAPI class using the API key provided.

The code then calls the CreateCompletionAsync method on the API object, passing in a CompletionRequest 
object that includes the prompt and the name of the model to use (text-davinci-003 in this case).

The API call returns a CompletionResult object that contains a list of Choice objects. 
The code retrieves the first choice and its Message property, which contains the converted TSQL code.

Finally, the converted TSQL code is printed to the console with Console.WriteLine.

*/

using OpenAI_API;
using OpenAI_API.Completions;
using System.Text;

internal class Program
{
    public static string API_KEY = "ENTER YOUR API KEY HERE";
    private static async Task Main(string[] args)
    {
        // Prompt for SQL code
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Enter SQL code. Press enter twice to finish:");
        Console.ResetColor();

        var sqlCodeBuilder = new StringBuilder();
        string? sqlCodeLine;

        // Read multiple lines of input
        do
        {
            sqlCodeLine = Console.ReadLine();
            sqlCodeBuilder.AppendLine(sqlCodeLine);
        } while (!string.IsNullOrWhiteSpace(sqlCodeLine));

        string sqlCode = sqlCodeBuilder.ToString().Trim();

        string Prompt = $"Convert the following SQL code to TSQL:\n\n{sqlCode}";

        var api = new OpenAIAPI(API_KEY);

        try
        {
            var result = await api.Completions.CreateCompletionAsync(
                new CompletionRequest(Prompt, model: "text-davinci-003")
            );

            var reply = result.ToString();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"TSQL-Convert: {reply.Trim()}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ResetColor();
        }
    }
}

