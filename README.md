# C# Mastermind Game

This is a simple implementation of the Mastermind game in C#. The game is played between a code maker and a code breaker. The code maker chooses a secret code and the code breaker tries to guess the code. After each guess, the code maker provides feedback to the code breaker on the correctness of the guess.

### Getting Started

To play the game, simply run the ConsoleController.Play() method in the Program.cs file. This will start a new game with a human player as the code breaker and a computer player as the code maker. You can modify the GetPlayers() method in the ConsoleController.cs file to change the players.

### Rules

The game is played with colored pegs. The code maker chooses a secret code of four pegs from a set of six colors (black, blue, green, red, white, and yellow). The code breaker tries to guess the code by making a series of guesses. After each guess, the code maker provides feedback to the code breaker in the form of black and white pegs.

A black peg indicates that a guessed peg is the correct color and in the correct position. A white peg indicates that a guessed peg is the correct color but in the wrong position. The order of the pegs in the feedback does not correspond to the order of the guessed pegs.

The code breaker has twelve attempts to guess the code. If the code breaker guesses the code correctly within twelve attempts, they win the game. Otherwise, the code maker wins the game.

### Acknowledgments

This implementation of the Mastermind game is based on the classic board game created by Mordecai Meirowitz in 1970. The code is written in C# and uses .NET Core 3.1.