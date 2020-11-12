﻿using ArmchairExpertsCom.Pages.Models.Interfaces;
using ArmchairExpertsCom.Pages.Models.Utilities;

namespace ArmchairExpertsCom.Pages.Models
{
    public class BookEvaluation : IModel
    {
        [MetaData]
        public bool IsNew { get; set; }
        
        [MetaData]
        public bool IsChanged { get; set; }
        
        [MetaData]
        public bool IsDeleted { get; set; }
        
        
        public int Id { get; set; }
        public int Value { get; set; }
        
        
        [ForeignKey(typeof(User))]
        public DbSet User { get; set; }
        
        [ForeignKey(typeof(Book))]
        public DbSet Book { get; set; }
        
        
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