using System;
using System.Collections.Generic;
using System.Text;

namespace BoasPraticas.Domain.Entities
{
    public class Email
    {
        public Email(string address)
        {
            SetAddress(address);
        }

        public string Address { get; private set; }

        public void SetAddress (string address)
        {
            if(!string.IsNullOrEmpty(address))
               Address = address;
        }
    }
}
