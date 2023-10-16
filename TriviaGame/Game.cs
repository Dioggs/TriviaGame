using System.Runtime.CompilerServices;

namespace TriviaGame;

public class Game
{
    private readonly List<Question> _questions = new()
    {
        new Question()
        {
            QuestionStr = "Sharks are mammals",
            Answer = false
        },
        new Question()
        {
            QuestionStr = "Sea otters have a favorite rock they use to break open food",
            Answer = true
        },
        new Question()
        {
            QuestionStr = "The blue whale is the biggest animal to have ever lived",
            Answer = true
        },
        new Question()
        {
            QuestionStr = "The hummingbird egg is the world's smallest bird egg",
            Answer = true
        },
        new Question()
        {
            QuestionStr = "Pigs roll in the mud because they don't like being clean",
            Answer = false
        },
        new Question()
        {
            QuestionStr = "Bats are blind",
            Answer = false
        },
        new Question()
        {
            QuestionStr = "A dog sweats by panting its tongue",
            Answer = false
        },
        new Question()
        {
            QuestionStr = "It takes a sloth two weeks to digest a meal",
            Answer = true
        },
        new Question()
        {
            QuestionStr = "An ant can lift 1,000 times its body weight",
            Answer = false
        },
        new Question()
        {
            QuestionStr = "When exiting a cave, bats always go in the direction of the wind",
            Answer = false
        },
        new Question()
        {
            QuestionStr = "Galapagos tortoises sleep up to 16 hours a day",
            Answer = true
        },
        new Question()
        {
            QuestionStr = "A monkey was the first non-human to go into space",
            Answer = false
        }
    };

    private readonly List<int> _usedQuestions = new();
    private readonly Random _rnd = new();
    private int _wins;
    private int _losses;
    
    public void Run()
    {
        PrintIntroduction();
        
        for (int i = 0; i < Enumerable.Range(0, _questions.Count).Count(); i++)
        {
            
            int randomIndex;
          
            while (true)
            {
                randomIndex = _rnd.Next(0, _questions.Count);

                if (_usedQuestions.Contains(randomIndex) == false) break;
            }
            
            Question randomQuestion = _questions[randomIndex];
            
            _usedQuestions.Add(randomIndex);
    
            PrintQuestionsAndGetPlayerInput(randomQuestion);
        }
        
        PrintResults();
    }

    private void PrintIntroduction()
    {
        WriteLine(@"
              _______   _       _          _____                      
             |__   __| (_)     (_)        / ____|                     
                | |_ __ ___   ___  __ _  | |  __  __ _ _ __ ___   ___ 
                | | '__| \ \ / / |/ _` | | | |_ |/ _` | '_ ` _ \ / _ \
                | | |  | |\ V /| | (_| | | |__| | (_| | | | | | |  __/
                |_|_|  |_| \_/ |_|\__,_|  \_____|\__,_|_| |_| |_|\___|                                                             
        ");
        WriteLine("Welcome to the Trivia Game! you'll be given a couple random questions to answer");
        WriteLine("Good luck my friend! These questions are quite hard");
    }
    private void PrintQuestionsAndGetPlayerInput(Question question)
    {
        WriteLine(string.Join("", Enumerable.Range(0, question.QuestionStr.Length).Select(_ => "-")));
        WriteLine(question.QuestionStr);
        WriteLine(string.Join("", Enumerable.Range(0, question.QuestionStr.Length).Select(_ => "-")));
       
        string playerInput;
        bool validInput;

        do
        {
            WriteLine();
            Write("> ");
            playerInput = ReadLine()!;
            WriteLine();
        } 
        while (bool.TryParse(playerInput == "true" ? "1" : "0", out validInput));
       
        if (validInput == question.Answer)
        {
            WriteLine("Congratulations! you got one right\n");
            _wins++;
        }
        else
        {
            WriteLine("Oh no! you got that one wrong\n");
            _losses++;
        }
    }
    private void PrintResults()
    {
        WriteLine(@"
            ______                _ _       
            | ___ \              | | |      
            | |_/ /___  ___ _   _| | |_ ___ 
            |    // _ \/ __| | | | | __/ __|
            | |\ \  __/\__ \ |_| | | |_\__ \
            \_| \_\___||___/\__,_|_|\__|___/                        
        ");
        
        WriteLine("-------------------");
        WriteLine($"WINS:   {_wins}");
        WriteLine($"LOSSES: {_losses}");
        WriteLine("-------------------");
    }
}