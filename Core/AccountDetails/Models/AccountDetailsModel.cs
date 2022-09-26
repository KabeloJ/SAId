using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Core.AccountDetails.Models
{
    public class AccountDetailsModel
    {
        public AccountDetailsModel()
        {
            PopulateNationalities();
            IsPostalAddressSameAsPhysical = true;
        }
        public string Id { get; set; } = null!;
        public string AspNetUserId { get; set; } = null!;
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstNames { get; set; } = null!;
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; } = null!;
        public string? MaidenName { get; set; }
        [Required(ErrorMessage = "Initials are required")]
        public string? Initials { get; set; }
        [Required(ErrorMessage = "Nationality is required")]
        public string? Nationality { get; set; }
        [Required(ErrorMessage = "Country Of Birth is required")]
        public string? CountryOfBirth { get; set; }
        [Required(ErrorMessage = "Date Of Birth is required")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Place Of Birth is required")]
        public string? PlaceOfBirth { get; set; }
        public string? HomeTelNo { get; set; }
        public string? IdNumber { get; set; }
        public string? WorkTelNo { get; set; }
        [Required(ErrorMessage = "Cell no is required")]
        public string? CellNo { get; set; }
        [Required(ErrorMessage = "Valid email address is required")]
        public string EmailAddress { get; set; } = null!;
        [Required(ErrorMessage = "Marital Status is required")]
        public string? MaritalStatus { get; set; }
        public string? PhysicalUnitNumber { get; set; }
        public string? PhysicalComplex { get; set; }
        [Required(ErrorMessage = "Street number is required")]
        public string? PhysicalStreetNumber { get; set; }
        [Required(ErrorMessage = "Street name is required")]
        public string? PhysicalStreetName { get; set; }
        [Required(ErrorMessage = "Suburb is required")]
        public string? PhysicalSuburb { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string? PhysicalCity { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        public string? PhysicalPostalCode { get; set; }
        public string? CountryCode { get; set; }
        public bool? IsPostalAddressSameAsPhysical { get; set; }
        public bool isPostalAddressSameAsPhysical { get; set; } = true;
        public string? PostalUnitNumber { get; set; }
        public string? PostalComplex { get; set; }
        public string? PostalStreetNumber { get; set; }
        public string? PostalCity { get; set; }
        public string? PostalPostalCode { get; set; }
        public string? PostalCountryCode { get; set; }

        public List<string> Nationalities { get;set; }
        public List<string> Errors { get; set; }
        public string? PostalSuburb { get; set; }
        [Required(ErrorMessage = "Please specify if you are a citizen")]
        public bool? IsSacitizen { get; set; }
        public string AppliedBy { get; set; } = null!;
        public string ApplicationStatus { get; set; } = null!;
        public string? ErrorMessage { get; set; }

        public FormExt FormExt { get; set; }

        void PopulateNationalities()
        {
            string jsonText = System.IO.File.ReadAllText("wwwroot\\Country.json");
            var countries = JsonConvert.DeserializeObject<Country>(jsonText);
            Nationalities = new List<string>();
            Nationalities = countries.Names;
        }
    }
    public class FormExt
    {
        public string ApplicationType { get; set; } = null!;
        public DateTime SubmissionDate { get; set; }
        public string ApplicationStatus { get; set; } = null!;
        public DateTime? ApprovedDate { get; set; }
        public string? ApprovedBy { get; set; }
    }
}
