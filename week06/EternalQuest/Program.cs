using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // Added a simple Level System.
        // The user levels up every 1000 points earned.
        // The level is displayed in the main menu.

        List<Goal> goals = new List<Goal>();
        int totalScore = 0;
        bool running = true;

        while (running)
        {
            int level = totalScore / 1000;

            Console.WriteLine("\n==============================");
            Console.WriteLine($"Current Score: {totalScore}");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goals);
                    break;

                case "2":
                    ListGoals(goals);
                    break;

                case "3":
                    RecordEvent(goals, ref totalScore);
                    break;

                case "4":
                    SaveGoals(goals, totalScore);
                    break;

                case "5":
                    LoadGoals(goals, ref totalScore);
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Selection: ");

        string type = Console.ReadLine();

        Console.Write("Enter Goal Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Description: ");
        string description = Console.ReadLine();

        Console.Write("Enter Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Enter Target Count: ");
            int targetCount = int.Parse(Console.ReadLine());

            Console.Write("Enter Bonus Points: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(name, description, points, targetCount, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    static void ListGoals(List<Goal> goals)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("\nNo goals created yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].GetName()} - {goals[i].GetDescription()}");
        }
    }

    static void RecordEvent(List<Goal> goals, ref int totalScore)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("\nNo goals available.");
            return;
        }

        ListGoals(goals);

        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int earnedPoints = goals[index].RecordEvent();
            totalScore += earnedPoints;

            Console.WriteLine($"You earned {earnedPoints} points!");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    static void SaveGoals(List<Goal> goals, int totalScore)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(totalScore);

            foreach (Goal goal in goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

  static void LoadGoals(List<Goal> goals, ref int totalScore)
{
    Console.Write("Enter filename to load: ");
    string filename = Console.ReadLine();

    if (!File.Exists(filename))
    {
        Console.WriteLine("File not found.");
        return;
    }

    string[] lines = File.ReadAllLines(filename);

    goals.Clear();
    totalScore = int.Parse(lines[0]);

    for (int i = 1; i < lines.Length; i++)
    {
        string[] parts = lines[i].Split(":");
        string goalType = parts[0];
        string[] data = parts[1].Split(",");

        if (goalType == "SimpleGoal")
        {
            SimpleGoal goal = new SimpleGoal(
                data[0],
                data[1],
                int.Parse(data[2]),
                bool.Parse(data[3])
            );

            goals.Add(goal);
        }
        else if (goalType == "EternalGoal")
        {
            EternalGoal goal = new EternalGoal(
                data[0],
                data[1],
                int.Parse(data[2])
            );

            goals.Add(goal);
        }
        else if (goalType == "ChecklistGoal")
        {
            ChecklistGoal goal = new ChecklistGoal(
                data[0],
                data[1],
                int.Parse(data[2]),
                int.Parse(data[4]),
                int.Parse(data[3]),
                int.Parse(data[5])
            );

            goals.Add(goal);
        }
    }

    Console.WriteLine("Goals loaded successfully.");
}
}
