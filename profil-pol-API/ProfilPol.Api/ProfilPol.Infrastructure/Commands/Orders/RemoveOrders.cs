using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.Commands.Orders
{
    public class RemoveOrders
    {
        public List<Guid> OrderIds { get; set; }
    }
}
