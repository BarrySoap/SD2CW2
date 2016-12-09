using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains values/properties for guests.
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    class Guests
    {
        private string guestFirstName;               // Create attributes for the guest(s) first name(s),
        private string guestSecondName;              // last name(s)
        private string guestPassNumber;              // passport number(s),
        private int guestAge;                        // and age(s).

        public string GuestFirstName
        {
            get { return guestFirstName; }
            set { guestFirstName = value; }
        }

        public string GuestSecondName
        {
            get { return guestSecondName; }
            set { guestSecondName = value; }
        }

        public string GuestPassNumber
        {
            get { return guestPassNumber; }
            set { guestPassNumber = value; }
        }

        public int GuestAge
        {
            get { return guestAge; }
            set { guestAge = value; }
        }
    }
}
