# SQL-to-TSQL Converter using OpenAI API

This code reads in any SQL code from the console, prompts the user to enter the code and then uses the OpenAI API to convert it to TSQL.

Tested with:

PL-SQL (Oracle)

## Decription

It starts by creating a `StringBuilder` object to accumulate the SQL code entered by the user. 
It then enters a loop where it reads in lines of input from the console until the user enters a blank line. 
Each line of input is added to the `StringBuilder` object with `AppendLine`.

After the input is read in, it creates a `Prompt` string that includes the SQL code entered by the user, 
and then creates an instance of the `OpenAIAPI` class using the API key provided.

The code then calls the `CreateCompletionAsync` method on the API object, passing in a `CompletionRequest` 
object that includes the prompt and the name of the model to use (`text-davinci-003` in this case).

The API call returns a `CompletionResult` object that contains a list of `Choice` objects. 
The code retrieves the first choice and its `Message` property, which contains the converted TSQL code.

Finally, the converted TSQL code is printed to the console with `Console.WriteLine`.

## Usage

1. Clone the repository
2. Navigate to the `SQL-to-TSQL-Converter` folder
3. Open `Program.cs` in a text editor
4. Replace `ENTER YOUR API KEY HERE` with your OpenAI API key
5. Save and close `Program.cs`
6. Open a command prompt in the `SQL-to-TSQL-Converter` folder
7. Run `dotnet run`

## Error handling

If an error occurs during the API call, the program will catch the exception and print an error message to the console.

## Dependencies

- .NET 5
- `OpenAI_API` (installed via NuGet) see: https://github.com/OkGoDoIt/OpenAI-API-dotnet


