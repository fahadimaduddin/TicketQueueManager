using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing Example 1:");
            var tickets1 = GetTicketsFromUser();
            var sortedTickets1 = ReorderTickets(tickets1);
            Console.WriteLine("Sorted Tickets for Example 1:");
            PrintTickets(sortedTickets1);

            Console.WriteLine("\nProcessing Example 2:");
            var tickets2 = GetTicketsFromUser();
            var sortedTickets2 = ReorderTickets(tickets2);
            Console.WriteLine("Sorted Tickets for Example 2:");
            PrintTickets(sortedTickets2);

            Console.ReadLine(); // Keep the console open
        }

        static List<int[]> GetTicketsFromUser()
        {
            Console.WriteLine("Enter the number of tickets:");
            int ticketCount;
            while (!int.TryParse(Console.ReadLine(), out ticketCount) || ticketCount < 0)
            {
                Console.WriteLine("Invalid input. Please enter a non-negative integer:");
            }

            var tickets = new List<int[]>();
            Console.WriteLine("Enter tickets in the format 'timestamp priority' (e.g., '4 3'):");
            for (int i = 0; i < ticketCount; i++)
            {
                Console.Write($"Ticket {i + 1}: ");
                var input = Console.ReadLine()?.Split();
                if (input == null || input.Length != 2 ||
                    !int.TryParse(input[0], out int timestamp) ||
                    !int.TryParse(input[1], out int priority) ||
                    priority < 1 || priority > 5 || timestamp < 0)
                {
                    Console.WriteLine("Invalid input. Please enter two integers: 'timestamp priority', where priority is between 1 and 5.");
                    i--; // Retry this ticket
                    continue;
                }
                tickets.Add(new int[] { timestamp, priority });
            }

            return tickets;
        }

        static List<int[]> ReorderTickets(List<int[]> tickets)
        {
            if (tickets == null || tickets.Count == 0)
                return new List<int[]>(); // Handle empty input

            // Sort tickets by priority first, then by timestamp
            return tickets
                .OrderBy(ticket => ticket[1]) // Priority (1 is highest, so sort ascending)
                .ThenBy(ticket => ticket[0]) // Timestamp (earlier timestamps first)
                .ToList();
        }

        static void PrintTickets(List<int[]> tickets)
        {
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"[{ticket[0]}, {ticket[1]}]");
            }
        }
    }
}
