using AutoMapper;
using Comm100.Public.Account.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Public.Account.Dto
{
    public class AgentMapperProfile : Profile
    {
        public AgentMapperProfile()
        {
            CreateMap<Agent, AgentRefDto>();
        }
    }
}
