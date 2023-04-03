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

