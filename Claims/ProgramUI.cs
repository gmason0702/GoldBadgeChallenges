using Claims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _claimRepo = new ClaimsRepository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            //                       Choose a menu item:
            //                  1.See all claims
            //                  2.Take care of next claim
            //                  3.Enter a new claim

            bool continueToRun = true;
            Console.Clear();
            while (continueToRun)
            {
                Console.WriteLine("Please choose from the menu below:\n" +
                    "1.)  See all claims\n" +
                    "2.)  Take care of next claim\n" +
                    "3.)  Enter a new claim\n" +
                    "4.)  Exit menu");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");

                switch (userInput)
                {
                    case "1":
                        DisplayAllClaims();
                        break;
                    case "2":
                        //Take care of next claim
                        DisplayNextClaim();
                        break;
                    case "3":
                        //Enter a new claim
                        EnterNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> claimDirectory = _claimRepo.GetAllClaims();

            Console.WriteLine($"{"ID",-10}{"Claim Type",-15}{"Description",-25}{"Claim $", -10}{"Date of Incident",-20}{"Date of Claim",-20}{"Is Claim Valid?"}");
            Console.WriteLine("=======================================================================================================================");
            foreach (Claim claim in claimDirectory)
            {
                Console.WriteLine($"\n{claim.ClaimID,-10}{claim.TypeOfClaim, -15}{claim.Description,-25}{claim.ClaimAmount,-10}{claim.DateOfIncident.ToShortDateString(), -20}{claim.DateOfClaim.ToShortDateString(),-20}{claim.IsValid}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private void DisplayNextClaim()
        {
            Console.Clear();
            Claim nextQueue = _claimRepo.PeekQueue();
            Console.WriteLine($"Claim ID: {nextQueue.ClaimID}\n" +
                  $"Type of Claim:  {nextQueue.TypeOfClaim}\n" +
                  $"Description:  {nextQueue.Description}\n" +
                  $"Claim Amount:  {nextQueue.ClaimAmount}\n" +
                  $"Date of Incident:  {nextQueue.DateOfIncident}\n" +
                  $"Date of Claim:  {nextQueue.DateOfClaim}\n" +
                  $"IsValid:  {nextQueue.IsValid}\n\n");
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            char response = Console.ReadKey().KeyChar;
            if (response == 'y')
            {
                Console.WriteLine("\n");
                _claimRepo.GetNextClaim();
            }
            else if(response == 'n')
            {
                RunMenu();
            }
            else
            {
                Console.WriteLine("Please enter either y or n");
                DisplayNextClaim();
            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claim addNewClaim = new Claim();
            Console.WriteLine("Please enter a claim ID");
            addNewClaim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the number of the type of claim\n" +
                "1.)  Car\n" +
                "2.)  Home\n" +
                "3.)  Theft");
            string claimTypeString = Console.ReadLine();
            int claimTypeID = int.Parse(claimTypeString);
            addNewClaim.TypeOfClaim = (Claim.ClaimType)claimTypeID;

            Console.WriteLine("Please enter a claim amount");
            addNewClaim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Please enter the date of the incident(YYYY/MM/DD)");
            addNewClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Pleae enter the date of the claim(YYYY/MM/DD)");
            addNewClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            string isClaimValid = (addNewClaim.IsValid) ? "Claim is valid" : "Claim is not valid";
            Console.WriteLine(isClaimValid);
            _claimRepo.AddClaimToDirectory(addNewClaim);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private void SeedContent()
        {
            Claim claimOne = new Claim(1, Claim.ClaimType.Car, "Car Accident on 464", 400.00m, 
                new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            _claimRepo.AddClaimToDirectory(claimOne);
            Claim claimTwo = new Claim(2, Claim.ClaimType.Theft, "Stuff was stolen", 8000.85m, new DateTime(2018, 05, 20), new DateTime(2018, 11, 12));
            _claimRepo.AddClaimToDirectory(claimTwo);

        }
    }

}
