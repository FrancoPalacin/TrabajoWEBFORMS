using System;
using System.Collections.Generic;

namespace domain
{
    public class Brand
    {
        public Brand()
        {

        }

        public Brand(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }

    }
}