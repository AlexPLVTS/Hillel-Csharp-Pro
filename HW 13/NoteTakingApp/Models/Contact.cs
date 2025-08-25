namespace NoteTakingApp.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string? AlternativeMobilePhone { get; set; }
        public string Email { get; set; }
        public string ShortDescription { get; set; }

        public Contact(string name, string mobilePhone, string email, string shortDescription, string? alternativeMobilePhone = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Contact name cannot be empty.", nameof(name));
            }
            Name = name;
            MobilePhone = mobilePhone;
            Email = email;
            ShortDescription = shortDescription;
            AlternativeMobilePhone = alternativeMobilePhone;
        }
    }
}
