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
            get
            {
                return guestFirstName;
            }
            set
            {
                if (guestFirstName.Length == 0)
                {
                    MessageBox.Show("First name field cannot be blank!");
                } else
                {
                    guestFirstName = value;
                }
            }
        }

        public string GuestSecondName
        {
            get
            {
                return guestSecondName;
            }
            set
            {
                if (guestSecondName.Length == 0)
                {
                    MessageBox.Show("Second name field cannot be blank!");
                } else
                {
                    guestSecondName = value;
                }
            }
        }

        public string GuestPassNumber
        {
            get
            {
                return guestPassNumber;
            }
            set
            {
                if (guestPassNumber.Length > 0 && guestPassNumber.Length < 11)
                {
                    guestPassNumber = value;
                } else
                {
                    MessageBox.Show("Invalid value! Passport value must be between 1-10 characters!");
                }
                
            }
        }

        public int GuestAge
        {
            get
            {
                return guestAge;
            }
            set
            {
                if (guestAge > 0 && guestAge < 102)
                {
                    guestAge = value;
                } else
                {
                    MessageBox.Show("Invalid age! You must be between 0-102 years old to enjoy this holiday!");
                }
                
            }
        }
    }
}
