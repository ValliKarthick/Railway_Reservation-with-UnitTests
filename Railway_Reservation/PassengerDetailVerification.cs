using System;
using System.Text.RegularExpressions;

namespace Railway_Reservation
{
    public class PassengerDetailVerification
    {
        public bool CheckPassengerId(string passengerId)
        {
            Regex patternForPassengerId = new Regex(@"^[A-Z]{2}\d{5}[A-Z]$");

            if (patternForPassengerId.IsMatch(passengerId))
            {
                return true;
            }
            return false;
        }

        public int GetTicketCost(int passengerAge)
        {
            if (passengerAge <= 5)
                return 0;
            else if (passengerAge >= 60)
                return 250;
            else return 500;
        }
    }
}
