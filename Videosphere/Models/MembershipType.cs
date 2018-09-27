using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videosphere.Models
{
    public class MembershipType
    {
        public byte Id { get; set; } //name convension: dla primary key powinno byc Id lub nazwa_typuId
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}