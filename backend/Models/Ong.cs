using System;
using System.Collections.Generic;
using FluentValidation;

namespace backend.Models
{
    public class Ong : Entity
    {
        public Ong(string id, string name, string email, string password, string whatsapp, string city, string uf)
        {
            if (id == null)
            {
                Id = Guid.NewGuid().ToString().Substring(0, 8);
            }
            else
            {
                Id = id;
            }

            Name = name;
            Email = email;
            Password = password;
            Whatsapp = whatsapp;
            City = city;
            Uf = uf;
            Incidents = new List<Incident>();
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Whatsapp { get; private set; }
        public string City { get; private set; }
        public string Uf { get; private set; }

        public List<Incident> Incidents { get; private set; }


        public void HashPassword()
        {
            this.Password = BCrypt.Net.BCrypt.HashPassword(this.Password);
        }

        public Ong GetOng()
        {
            Ong clone = (Ong)this.MemberwiseClone();

            clone.Password = null;
            return clone;
        }
    }
}