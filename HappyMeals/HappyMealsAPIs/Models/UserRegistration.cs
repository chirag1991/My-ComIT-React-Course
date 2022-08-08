namespace HappyMealsAPIs.Models
{
    public class UserRegistration
    {
        public int RegistrationId { get; set; }
        public string Prefix { get;set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }


    }
}
