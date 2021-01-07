# 5th Dimension .NET

This is a console app that allows a user to search the Google Books API.

This was written in C# as a tool to learn the language and .NET 5.0.

## Getting Started

1. Make sure you have the [.NET 5.0 SDK](https://dotnet.microsoft.com/download) installed
    - It may help to restart your command line if it's already open.
2. Clone this repo
    ```
    $ git clone https://github.com/k3ntako/5th-Dimension-.NET.git
    ```
3. Create an Google Books API Key
    - More instruction [here](https://developers.google.com/books/docs/v1/using#APIKey)
    - This program uses an API Key not OAuth.
    - Make sure to restrict the API key to prevent unauthorized use.
4. Create a file called `ApiKeys.json` in the project directory (where this ReadMe file exists).
    - Copy the following and replace `[YOUR KEY]` with the API key you generated.
    ```
    {
      "GoogleBooksApiKey": "[YOUR KEY]"
    }
    ```
5. In your command line, navigate to the project directory (where this ReadMe file exists).
6. Run the program!
    - This command will build and run the program.
    ```
    $ dotnet run
    ```

## Resources

These are resources I found helpful.

- [Install/Manage NuGet Packages](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio)
- [Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/getting-started-with-unit-testing?view=vs-2019&tabs=mstest)
- [API Calls](https://johnthiriet.com/efficient-api-calls/)
- [Including Files in Build](https://stackoverflow.com/questions/16701869/how-do-i-get-a-text-file-to-be-a-part-of-my-build)
    - When adding an ignored JSON file, I had trouble getting the file to be included in the build. Changing the file's properties helped resolve this issue.