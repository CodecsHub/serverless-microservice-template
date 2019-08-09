using ServerlessMicroservice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessMicroservice.Domain.Entities
{
    public class Activity : BaseEntity
    {

        public int ApplicationId { get; set; }
        public int ActionId { get; set; }
        public string ApplicationUrl { get; set; }
        public string ActivityRemarks { get; set; }

        public long UserId { get; set; }
        public User User { get; set; } // many to one see <c>User.cs<c>
      





        // this is for look up entity code whenever pointing to one to many class/relationship
        //public IList<Product> Products { get; set; } = new List<Product>();
    }
}
