using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videosphere.Models;

namespace Videosphere.ViewModels
{
    public class CustomerEditFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}

//Zamiast IEnumerable moge tez List ale generalnie tutaj nie potrzebuje
//metod z list, potrzebuje tylko iterowac przez MembershipTypes.