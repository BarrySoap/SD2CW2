using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2
{
    class Facade
    {
        private DeleteBooking delbook;
        private DeleteCustomer delcust;
        private DeletionHelp delHelp;

        public Facade()
        {
            delbook = new DeleteBooking();
            delcust = new DeleteCustomer();
            delHelp = new DeletionHelp();
        }

        public void deleteBooking(double temp)
        {
            delHelp.checkBookingValidity(temp);
            delHelp.deleteBooking(delbook.bookingPath, temp);
        }

        public void deleteCustomer(double temp)
        {
            delHelp.checkCustomerValidity(temp);
            delHelp.deleteCust(delcust.customerPath, temp);
        }
    }
}
