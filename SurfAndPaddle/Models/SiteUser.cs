using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;



namespace SurfAndPaddle.Models
{
    public class SiteUser
    {
       
        public Guid ID = Guid.NewGuid();
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImgFilename { get; set; }

        public SiteUser(string userId, string firstName, string lastName, string imgFilename)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = LastName;
            ImgFilename = imgFilename;
            VerifyUserIdIsNew(userId);

        }

        private bool VerifyUserIdIsNew(string userId)
        {
          if App
        }
    }
}