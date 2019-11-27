using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Framework.AutoMapper;
using Comm100.Public.Account.Domain;

namespace Comm100.Public.Account.Dto
{
    [AutoMapFrom(typeof(Agent))]
    public class AgentRefDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }
    }
}
