using FrameworkAgnostic.Common.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application
{
    public  class CustomerMappingProfile : MappingProfile
    {
        public CustomerMappingProfile() 
        {
            ApplyMappingsFromAssembly(typeof(CustomerMappingProfile).Assembly);
        }
    }
}
