﻿using PersonalFinances.Domain.Core.Model;

namespace PersonalFinances.Domain.Accounts
{
    public class Frequency
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Frequency(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

    }
}