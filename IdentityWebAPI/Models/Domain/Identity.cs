namespace IdentityWebAPI.Models.Domain
{
    public class Identity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public int ImageId { get; set; }

        //Navigation Property
        public Image Image { get; set; }
    }
}
