# 5th Dimension .NET

5th Dimension is a tool that allows users to search for books using the Google Books API.

This .NET solution contains two applications, a console app and a web app.
The console version was developed first. While creating the web version,
I used the logic for fetching books from the console version with minor changes to the original code.
This accomplished the goal of writing reusable code that is as platform indendent as possible. 

They were written in C# as a tool to learn the language and .NET 5.0. The frontend for the web app was written in React.

## Getting Started

1. Clone this repo
    ```
    $ git clone https://github.com/k3ntako/5th-Dimension-.NET.git
    ```
2. Read the instructions for the app you would like to use:
    - [Console app](https://github.com/k3ntako/5th-Dimension-.NET/blob/master/ConsoleApp/ReadMe.md)
    - [Web app](https://github.com/k3ntako/5th-Dimension-.NET/blob/master/WebApp/ReadMe.md)

## Resources

These are resources I found helpful.

- [Install/Manage NuGet Packages](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio)
- [Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/getting-started-with-unit-testing?view=vs-2019&tabs=mstest)
- [API Calls](https://johnthiriet.com/efficient-api-calls/)
- [Including Files in Build](https://stackoverflow.com/questions/16701869/how-do-i-get-a-text-file-to-be-a-part-of-my-build)
    - When adding an ignored JSON file, I had trouble getting the file to be included in the build. Changing the file's properties helped resolve this issue.
- [Naming convention](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/capitalization-conventions)