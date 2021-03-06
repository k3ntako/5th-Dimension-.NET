﻿# 5th Dimension .NET Console App

This is the console app project. Please see the [solution's ReadMe](https://github.com/k3ntako/5th-Dimension-.NET/blob/master/ReadMe.md) for more information.

## Getting Started

1. Make sure you have the [.NET 5.0 SDK](https://dotnet.microsoft.com/download) installed.
   - You may need to restart your command line if it is already open.
2. Read the ReadMe in the solution directory.
3. Create an Google Books API Key
   - More instruction [here](https://developers.google.com/books/docs/v1/using#APIKey)
   - This program uses an API Key not OAuth.
   - Make sure to restrict the API key to prevent unauthorized use.
   - **If you already created one for the WebApp, you can reuse the same key**.
     - Make sure that your key restrictions allow for use in both apps.
4. Create a file called `env.json` in the project directory (where this ReadMe file exists).
   - Copy the following and replace `[YOUR KEY]` with the API key you generated.
   ```
   {
     "GoogleBooksApiKey": "[YOUR KEY]"
   }
   ```
5. In your command line, navigate to the project directory (where this ReadMe file exists).
6. Run the program!
   - This command will build and run the program.
   - You made need to install/configure HTTPS certificates on your first run.
   ```
   $ dotnet run
   ```
7. In your browser, go to the localhost URL printed in the console.

## Enviroment Variables

In addition to the API Key mentioned in Getting Started, you can add `LogFilePath`
(default: `./logs.log`). This will specify the location the log files will be created.
