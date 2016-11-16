using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains values/properties for bookings
 * Date last modified: 28/10/2016
 */

namespace CW2
{
    class Booking
    {
        private DateTime arrivalDate = DateTime.MinValue;           // Values are initialised as
        private DateTime departureDate = DateTime.MinValue;         // "01 January 0001"
        private double refNumber = 0;

        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }

        public DateTime DepartureDate
        {
            get { return departureDate; }
            set { departureDate = value; }
        }

        public double RefNumber
        {
            get { return refNumber; }
            set { refNumber = value; }
        }
            
    }
}
