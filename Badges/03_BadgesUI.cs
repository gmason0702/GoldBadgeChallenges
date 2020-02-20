using BadgesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgesUI
    {
        private readonly Repository _badgesRepo = new Repository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }


        private void RunMenu()
        {
            //Hello Security Admin, What would you like to do?

            //            Add a badge
            //            Edit a badge.
            //List all Badges

            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, what would you like to do?\n\n" +
                    "1.)  Add a badge\n" +
                    "2.)  Edit a badge\n" +
                    "3.)  List all badges\n" +
                    "4.)  Exit menu");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //add a badge
                        Console.Clear();
                        AddBadge();
                        break;
                    case "2":
                        //edit a badge
                        Console.Clear();
                        UpdateBadge();
                        break;
                    case "3":
                        //List all badges
                        Console.Clear();
                        ListAllBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge?");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            List<string> doors = new List<string>();
            Console.WriteLine("List a door that the badge needs access to:\n");
            doors.Add(Console.ReadLine());
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Any other doors?(y/n)");
                char answer = Console.ReadKey().KeyChar;
                
                if (answer == 'y')
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("List a door that it needs access to:");
                    doors.Add(Console.ReadLine());
                    Console.Clear();
                }
                else
                {
                    keepGoing = false;
                }
            }
            Badge newBadge = new Badge(badgeID, doors);
            _badgesRepo.AddBadgeToDictionary(newBadge);
        }

        public void RemoveDoor(int badgeID)
        {
            Console.WriteLine("What door would you like removed?");
            string doorRemoved = Console.ReadLine();

            _badgesRepo.RemoveDoorFromBadge(badgeID, doorRemoved);
        }
        public void RemoveAllDoors(int badgeID)
        {
            Console.WriteLine($"Would you like to remove all door access for badge {badgeID}?(y/n)");
            char response = Console.ReadKey().KeyChar;
            if (response =='y')
            {
                Console.WriteLine("\n");
                _badgesRepo.RemoveAllDoorsFromBadge(badgeID);
                Console.WriteLine("Door access has been removed for this badge. Press any key to continue...");
                Console.ReadKey();
                
            }
            else 
            {
                UpdateBadge();
            }
           
        }

        public void AddDoor(int badgeID)
        {
            Dictionary<int, List<string>> badgeDictionary = _badgesRepo.GetAllBadges();
            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                if (badge.Key==badgeID)
                {
                    Console.WriteLine("Which door would you like to add?");
                    string newDoor = Console.ReadLine();
                    badge.Value.Add(newDoor);
                }
            }
        }
      
        public void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            int badgeIdInput = Convert.ToInt32(Console.ReadLine());
            List<string> existingDoors = _badgesRepo.GetAllBadges()[badgeIdInput];
            string doorString = string.Join(",", existingDoors);

            Console.WriteLine($"{badgeIdInput} has access to door(s) {doorString}");
            Console.WriteLine("What would you like to do?\n" +
                "1.)  Remove a door\n" +
                "2.)  Add a door\n" +
                "3.)  Remove all doors from badge");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    RemoveDoor(badgeIdInput);
                    break;
                case "2":
                    AddDoor(badgeIdInput);
                    break;
                case "3":
                    RemoveAllDoors(badgeIdInput);
                    break;
                default:
                    break;
            }
        }

        public void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgesList = _badgesRepo.GetAllBadges();
            foreach (int badgeID in badgesList.Keys)
            {
                string doors = string.Join(",", badgesList[badgeID]);
                Console.WriteLine($"Badge ID:  {badgeID}\tDoor Access:  {doors}");
            }
            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }

        public void SeedContent()
        {
            Badge badgeOne = new Badge(12345, new List<string> { "A7" });
            Badge badgeTwo = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge badgeThree = new Badge(32345, new List<string> { "A4", "A5" });
            Badge badgeFour = new Badge(12346, new List<string> { "A4", "A5", "A6" });

            _badgesRepo.AddBadgeToDictionary(badgeOne);
            _badgesRepo.AddBadgeToDictionary(badgeTwo);
            _badgesRepo.AddBadgeToDictionary(badgeThree);
            _badgesRepo.AddBadgeToDictionary(badgeFour);
        }
    }
}

