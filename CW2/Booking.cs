using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains values/properties for bookings
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    class Booking
    {
        private DateTime arrivalDate = DateTime.MinValue;           // Values are initialised as
        private DateTime departureDate = DateTime.MinValue;         // "01 January 0001"
        private double refNumber = 1;                               // Create a reference number for bookings, auto-incrementing from 1.

        private static Booking instance;                            // Create a singleton instance.

        private Booking()
        {

        }

        public static Booking Instance                              // Initialise a constructor for the instance.
        {
            get
            {
                if (instance == null)                               // Check if the instance has already been initialised.
                {
                    instance = new Booking();                       // If not, create it.
                }
                return instance;
            }
        }

        public DateTime ArrivalDate                                 // Basic getters/setters for arrival date,
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }

        public DateTime DepartureDate                               // departure date,
        {
            get { return departureDate; }
            set { departureDate = value; }
        }

        public double RefNumber                                     // and reference number.
        {
            get { return refNumber; }
            set { refNumber = value; }
        }
            
    }
}
