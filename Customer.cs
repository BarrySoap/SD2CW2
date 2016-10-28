using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2
{
    class Customer
    {
        private string firstName;
        private string secondName;
        private double custRefNumber = 1;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }

        public double CustRefNumber
        {
            get { return custRefNumber; }
            set { custRefNumber = value + 1; }
        }
    }
}
