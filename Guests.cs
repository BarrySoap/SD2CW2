using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CW2
{
    class Guests
    {
        private string guestFirstName;
        private string guestSecondName;
        private string guestPassNumber;
        private int guestAge;

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
