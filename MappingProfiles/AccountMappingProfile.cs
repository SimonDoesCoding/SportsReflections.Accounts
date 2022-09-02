using System;
using AutoMapper;
using SportReflections.Accounts.Api.DTOs;
using SportReflections.Accounts.Api.Models;

namespace SportReflections.Accounts.Api.MappingProfiles
{
    public class AccountMappingProfile : Profile
    {   
        public AccountMappingProfile()
        {
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>();
        }
    }
}

