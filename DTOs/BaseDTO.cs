﻿using System;
namespace SportReflections.Accounts.Api.DTOs
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

