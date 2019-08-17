using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using youtubeDemo.Shared.Model;

namespace youtubeDemo.Server
{
    public class PersondbContext :  DbContext
    {
        public PersondbContext(DbContextOptions<PersondbContext> options) : base(options)
        {

        }

        public DbSet<Persons> Experience { get; set; }
    }
}
