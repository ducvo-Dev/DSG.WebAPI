﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DSG.Model.Models
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser
    {
        [MaxLength(256)]
        public string FullName { set; get; }

        [MaxLength(256)]
        public string Address { set; get; }

        public string Avatar { get; set; }

        public DateTime? BirthDay { set; get; }

        public bool? Status { get; set; }

        public bool? Gender { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        //public class DSGDbContext : IdentityDbContext<AppUser>
        //{
        //    public ApplicationDbContext()
        //        : base("DsgConnection", throwIfV1Schema: false)
        //    {
        //    }

        //    public static ApplicationDbContext Create()
        //    {
        //        return new ApplicationDbContext();
        //    }
        //}
    }
}
