﻿using IdentityWebAPI.Models.Domain;

namespace IdentityWebAPI.Models.DTO
{
    public class UpdateIdentityRequest
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}
