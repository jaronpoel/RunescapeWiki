using System;

namespace Models
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }
        public string Strength { get; set; }
        public string Defence { get; set; }
        public string Attack { get; set; }
    }
}
