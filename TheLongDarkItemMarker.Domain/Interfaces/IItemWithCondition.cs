using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLongDarkItemMarker.Domain.Interfaces
{
    public interface IItemWithCondition
    {
        byte Condition { get; set; }
    }
}
