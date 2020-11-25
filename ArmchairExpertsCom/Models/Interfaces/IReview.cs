﻿using ArmchairExpertsCom.Models.Utilities;

namespace ArmchairExpertsCom.Models.Interfaces
{
    public interface IReview
    {
        public string Text { get; set; }
        public DbSet User { get; set; }
        public DbSet Comments { get; set; }
    }
}