# Developer Evaluation
A series of challenges presented to potential team members by the GSFS Group

## Get Started

### Required Dependencies
To properly build and run the different parts of this application, you will need the following dependencies installed
- [ASP.Net Core 3.1 Runtime](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [TypeScript 3.8](https://www.npmjs.com/package/typescript)

### Restoring Client npm Packages
In addition to the [Required Dependencies](#required-dependencies) to run the client application you will need to restore the npm libraries it uses. To do so, first open a shell or command window and navigate to the root directory of the `DeveloperEvaluation.API` project. Once you've navigated to the directory, run the follwing commands:

**Install Development Dependencies**
```shell
npm i -save
```

**Install Normal Dependencies**
```shell
npm i -save-dev
```

## Running the Code

### Running the Unit Tests (Challenges One and Two)
To run the unit tests for calculating resistor ohm and tolerance values, you'll need to have Visual Studio 2017 or 2019 installed and have access to the Microsoft Test Runner. To run the tests via the MS test runner in visual studio follow these steps:
1. Open Visual Studio 2017 or 2019
2. Open the `DeveloperEvaluation` solution
3. Rebuild the Solution to ensure all the tests are discovered
4. Run all the tests by:
 - Using the shortcut keys `Ctrl+R, A`
 - Navigating to the menu `Test > Run All Tests`
 - Opening the Test Explorer using `Ctrl+E, T` and running the tests there

### Running the Client App (Challenge Four)
The client application which contains a simple interface for entering different lexical strings and determining whether they have a valid set of closures or not. To run the client:
1. Open a command or shell window (the Package Manager Console will work as well)
2. Type the following npm command to start the [WebPack Dev Server](https://webpack.js.org/configuration/dev-server/):

`npm run server`

3. Once the dev server has built the typescript, run it by setting the `DeveloperEvaluation.API` project as the startup project and debugging.

## References
1. Main Source - [Wikipedia Page for Resistor Color Codes](https://en.wikipedia.org/wiki/Electronic_color_code#Resistors)
2. Additional Test Cases - [How To Calculate And Understand Resistor Values](https://www.kitronik.co.uk/blog/how-to-calculate-and-understand-resistor-values/)