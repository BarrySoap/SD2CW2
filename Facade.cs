using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains logic for a facade.
 * Date last modified: 09/12/2016
 */

namespace CW2
{
    class Facade
    {
        private DeleteBooking delbook;              // Initialise objects for deleting a booking,
        private DeleteCustomer delcust;             // deleting a customer,
        private DeletionHelp delHelp;               // and the helper window.

        public Facade()
        {
            delbook = new DeleteBooking();
            delcust = new DeleteCustomer();
            delHelp = new DeletionHelp();
        }

        public void deleteBooking(double temp)                  // Temp will be replaced with the respective reference number.
        {
            delHelp.checkBookingValidity(temp);                 // Use the method in the helper window for checking if a booking exists.
            delHelp.deleteBooking(delbook.bookingPath, temp);   // If it exists, delete it when prompted.
        }

        public void deleteCustomer(double temp)
        {
            delHelp.checkCustomerValidity(temp);                // Use the method in the helper window for checking if a customer exists.
            delHelp.deleteCust(delcust.customerPath, temp);     // If it exists, delete it when prompted.
        }
    }
}
