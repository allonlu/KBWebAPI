using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Public.Dto
{
    public class AgentMapperProfile : Profile
    {
        public AgentMapperProfile()
        {
            CreateMap<Agent, AgentRefDto>();
        }
    }
}
