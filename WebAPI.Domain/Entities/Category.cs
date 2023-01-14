using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; }
    }
}
