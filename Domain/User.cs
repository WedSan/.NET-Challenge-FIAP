﻿namespace Domain
{
    public class User
    {
        int Id {  get; init; }

        public string Name { get; init; }
        
        public string Email { get; set; }

        public string Password { get; set; }

        public Gender Gender { get; init; }

        public User(int id, string name, string email, string password, Gender gender)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Gender = gender;
        }
    }
}