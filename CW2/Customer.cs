using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains values/properties for customers.
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    class Customer
    {
        private string customerFirstName;               // Create attributes for first name,
        private string customerSecondName;              // last name,
        private string customerAddress;                 // address,
        private double custRefNumber = 0;               // and the customer reference number.

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
            set { custRefNumber = value; }
        }
    }
}
