using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcepts.Shared;

public class UserContext : IdentityDbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base (options)
    {
        
    }
}