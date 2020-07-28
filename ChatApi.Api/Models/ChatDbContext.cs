﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Models
{
    public class ChatDbContext: DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options): base(options)
        {
                
        }

        public DbSet<Message> Messages { get; set; }
    }
}
