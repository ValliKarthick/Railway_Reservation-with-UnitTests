using System;

namespace Railway_Reservation
{
    public class Program
    {
        public static void Main(string[] args)
        {            

            PassengerDetail PassengerDetail = new PassengerDetail();
            PassengerDetailVerification passengerDetailVerification = new PassengerDetailVerification();

            Console.WriteLine("Welcome To Railway Reservation Portal..!!");
            Console.WriteLine("Enter the following Details To Reserve Your Ticket");

            //Get the PassengerId in the PassengerDetail object and Call the CheckPassengerId method from PassengerDetailVerification class

            GetPassengerID:
            Console.WriteLine("Passenger Id (Format eg - AB12345L): ");
            PassengerDetail.PassengerId = Console.ReadLine();
        
            bool isIdValid = passengerDetailVerification.CheckPassengerId(PassengerDetail.PassengerId);

            //If Id is valid, Get the remaining Passenger details and store it in the PassengerDetail object

            if(isIdValid)
            {
                Console.WriteLine("Passenger Name: ");
                PassengerDetail.PassengerName = Console.ReadLine();
                Console.WriteLine("Passenger Age: ");
                PassengerDetail.PassengerAge = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Travel Source: ");
                PassengerDetail.TravelSource = Console.ReadLine();
                Console.WriteLine("Travel Destination: ");
                PassengerDetail.TravelDestination = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid Passenger Id !! ");
                Console.WriteLine("Try Again !! ");
                goto GetPassengerID;
            }

            //Get ticket Cost from passengerDetailVerification class
            int TicketCost = passengerDetailVerification.GetTicketCost(PassengerDetail.PassengerAge);


            //Display the output using object along with the Cost of the Ticket
            Console.WriteLine("----------");
            Console.WriteLine("Passenger Id - " + PassengerDetail.PassengerId);
            Console.WriteLine("Name - " + PassengerDetail.PassengerName);
            Console.WriteLine("Age - " + PassengerDetail.PassengerAge);
            Console.WriteLine("Your Ticket Cost is "+TicketCost+"/-. Verify the above details to checkout to Payment portal..");
            Console.WriteLine("Thank You....");
            Console.WriteLine("----------");
            Console.ReadLine();
        }
    }
}
