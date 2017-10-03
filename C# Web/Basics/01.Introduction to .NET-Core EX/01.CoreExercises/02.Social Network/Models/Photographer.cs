using System;
using System.Collections.Generic;
using _02.Social_Network.Models.Mappings;

namespace _02.Social_Network.Models
{
    public class Photographer
    {
        public Photographer()
        {
            this.Albums = new HashSet<AlbumsPhotographers>();
        }

        public int Id { get; set; }
        public string Username { get; set; }

        //should be byte[] to be precise
        public string Password { get; set; }

        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<AlbumsPhotographers> Albums { get; set; }
        public ICollection<Friendship> FromFriends { get; set; }
        public ICollection<Friendship> ToFriends { get; set; }
    }
}