using System;
using System.Collections.Generic;

class TaskItem {
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(string title, string description)
    {
        Title = title;
        Description = description;
        IsCompleted = false;
    }

    public void ToggleStatus() {
        IsCompleted = !IsCompleted;
    }

    public override string ToString() {
        return $"{Title} - {Description} [{(IsCompleted ? "Terminé" : "En cours")}]";
    }
}

class Program {
    static List<TaskItem> tasks = new List<TaskItem>();

    static void Main()
    {
        Console.WriteLine("Bienvenue dans le gestionnaire de tâches !");
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Ajouter une tâche");
            Console.WriteLine("2. Afficher les tâches");
            Console.WriteLine("3. Modifier une tâche");
            Console.WriteLine("4. Supprimer une tâche");
            Console.WriteLine("5. Quitter");

            Console.Write("Choisissez une option : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    DisplayTasks();
                    break;
                case "3":
                    EditTask();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Option invalide !");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Titre de la tâche : ");
        string title = Console.ReadLine();
        Console.Write("Description : ");
        string description = Console.ReadLine();

        tasks.Add(new TaskItem(title, description));
        Console.WriteLine("Tâche ajoutée !");
    }

    static void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Aucune tâche disponible.");
            return;
        }

        Console.WriteLine("\nListe des tâches :");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    static void EditTask()
    {
        DisplayTasks();
        Console.Write("Numéro de la tâche à modifier : ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks[index - 1].ToggleStatus();
            Console.WriteLine("Statut de la tâche mis à jour !");
        }
        else
        {
            Console.WriteLine("Numéro invalide !");
        }
    }

    static void DeleteTask()
    {
        DisplayTasks();
        Console.Write("Numéro de la tâche à supprimer : ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Tâche supprimée.");
        }
        else
        {
            Console.WriteLine("Numéro invalide !");
        }
    }
}
