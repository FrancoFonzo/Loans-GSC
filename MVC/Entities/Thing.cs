﻿namespace MVC.Entities
{
    public class Thing : EntityBase
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
