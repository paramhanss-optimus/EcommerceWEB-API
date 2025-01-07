

using AutoMapper;
using Ecommerce.Domain.DTO;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Ecommerce.Application.Mapping { 
    public class CustomerMapping
    {
        public static Mapper InitialiseMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDTO, CustomerEntity>().ForMember(dest => dest.custId, opt => opt.Ignore()));
            return new Mapper(config);
        }
    }
}