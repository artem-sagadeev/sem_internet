﻿using System;
using System.Collections.Generic;
using ArmchairExpertsCom.Pages.Models.Interfaces;
using ArmchairExpertsCom.Pages.Models.Utilities;
using Microsoft.AspNetCore.Routing;
using Npgsql;

namespace ArmchairExpertsCom.Pages.Models
{
    public class Book : IModel
    { 
        [MetaData]
        public bool IsNew { get; set; }
        
        [MetaData]
        public bool IsChanged { get; set; }
        
        [MetaData]
        public bool IsDeleted { get; set; }
        
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Authors { get; set; }
        public int Rating { get; set; }
        
        
        [ForeignKey(typeof(Image))]
        public DbSet Images { get; set; } = new DbSet();
        
        [ForeignKey(typeof(BookGenre))]
        public DbSet Genres { get; set; } = new DbSet();
        
        /*[ForeignKey(typeof(Review))]
        public DbSet Reviews { get; set; } = new DbSet();*/
        
        
        public void Save()
        {
            if (!Repository.Contains(this))
            {
                Repository.Add(this);
                IsNew = true;
            }
            else
                IsChanged = true;
        }
        
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}