using AutoMapper;
using Event.Core.DTO;
using Event.Core.Models;
using GlaTicket.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Client,ClientGetDTO>().ReverseMap();
            CreateMap<SingleEvent,EventGetDTO>().ReverseMap();
            CreateMap<SingleEvent, EventPostDTO>().ReverseMap();
            CreateMap<SingleEvent, EventGetListDTO>().ReverseMap();
            CreateMap<Producer,ProducerGetDTO>().ReverseMap();
            CreateMap<Ticket, TicketGetDTO>().ReverseMap();
            CreateMap<Ticket, TicketPostDTO>().ReverseMap();
        }
    }
}
