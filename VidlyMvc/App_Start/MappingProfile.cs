using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VidlyMvc.Models;
using VidlyMvc.Dtos;

namespace VidlyMvc.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Customer, CustomerDto>();
            //    cfg.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            //});
           CreateMap<Customer, CustomerDto>();
           CreateMap<CustomerDto, Customer>();
        }
         
    }
}