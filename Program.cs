using System;
using System.Collections.Generic;

// Classe représentant une tâche dans la To-Do List
class TaskItem {
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    // Constructeur de la classe TaskItem
    public TaskItem(string title, string description)
    {
        Title = title;
        Description = description;
        IsCompleted = false;
    }

    // Méthode pour inverser l'état de la tâche (pour passer de non terminée à terminée)
    public void ToggleStatus() {
        IsCompleted = !IsCompleted;
    }

    // La méthode ToString pour afficher les informations de la tâche, puis me retourner une chaîne de caractères contenant les informations de la tâche
    public override string ToString() {
        return $"{Title} - {Description} [{(IsCompleted ? "Terminé" : "En cours")}]";
    }
}

// Classe principale du programme
class Program {
    // Ceci est la liste pour stocker les tâches
    static List<TaskItem> tasks = new List<TaskItem>();

    // Point d'entrée de l'application
    static void Main()
    {
        Console.WriteLine("Bienvenue dans le gestionnaire de tâches !");
        bool running = true; // Cette variable va me permettre d'exécuter la boucle principale

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

    // Méthode pour ajouter une tâche
    static void AddTask()
    {
        Console.Write("Titre de la tâche : ");
        string title = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Le titre de la tâche ne peut pas être vide.");
            return;
        }

        Console.Write("Description : ");
        string description = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("La description de la tâche ne peut pas être vide.");
            return;
        }

        // Création d'une nouvelle tâche et ajout dans la liste
        tasks.Add(new TaskItem(title ?? string.Empty, description ?? string.Empty));
        Console.WriteLine("Tâche ajoutée !");
    }

    // Méthode pour afficher toutes les tâches
    static void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Aucune tâche disponible.");
            return;
        }

        // Affichage de la liste des tâches
        Console.WriteLine("\nListe des tâches :");
        for (int i = 0; i < tasks.Count; i++)
        {
            // Affiche chaque tâche avec son index dans la liste
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    // Méthode pour changer le statut d'une tâche
    static void EditTask()
    {
        DisplayTasks();
        Console.Write("Numéro de la tâche à modifier : ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            // Si l'index est valide, inverse le statut de la tâche (en cours <-> terminé)
            tasks[index - 1].ToggleStatus();
            Console.WriteLine("Statut de la tâche mis à jour !");
        }
        else
        {
            Console.WriteLine("Numéro invalide !");
        }
    }

    // Méthode pour supprimer une tâche
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
