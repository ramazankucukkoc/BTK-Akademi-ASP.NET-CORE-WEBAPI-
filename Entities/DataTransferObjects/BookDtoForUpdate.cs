using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record BookDtoForUpdate
    {
        public int ID { get; init; }
        public String Name { get; init; }
        public decimal Price { get; init; }
    }
    //record type özellikleri
    //1.readonly'dir
    //2.ctor içerir.
    //3.LINQ
    //4.Ref type
    //5.immutable
}
