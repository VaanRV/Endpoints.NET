﻿namespace WebApiNET.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime update_date { get; set; }

    }
}