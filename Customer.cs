using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2
{
    class Customer
    {
        private string customerFirstName;
        private string customerSecondName;
        private string customerAddress;
        private double custRefNumber = 1;

        public string CustomerFirstName
        {
            get { return customerFirstName; }
            set { customerFirstName = value; }
        }

        public string CustomerSecondName
        {
            get { return customerSecondName; }
            set { customerSecondName = value; }
        }

        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }

        public double CustRefNumber
        {
            get { return custRefNumber; }
            set { custRefNumber = value + 1; }
        }
    }
}
