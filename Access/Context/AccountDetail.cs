using System;
using System.Collections.Generic;

namespace Access.Context
{
    public partial class AccountDetail
    {
        public string AspNetUserId { get; set; } = null!;
        public string FirstNames { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? MaidenName { get; set; }
        public string? Initials { get; set; }
        public string? Nationality { get; set; }
        public string? CountryOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? HomeTelNo { get; set; }
        public string? WorkTelNo { get; set; }
        public string? CellNo { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string? MaritalStatus { get; set; }
        public string? PhysicalUnitNumber { get; set; }
        public string? PhysicalComplex { get; set; }
        public string? PhysicalStreetNumber { get; set; }
        public string? PhysicalStreetName { get; set; }
        public string? PhysicalSuburb { get; set; }
        public string? PhysicalCity { get; set; }
        public string? PhysicalPostalCode { get; set; }
        public string? CountryCode { get; set; }
        public bool? IsPostalAddressSameAsPhysical { get; set; }
        public string? PostalUnitNumber { get; set; }
        public string? PostalComplex { get; set; }
        public string? PostalStreetNumber { get; set; }
        public string? PostalCity { get; set; }
        public string? PostalPostalCode { get; set; }
        public string? PostalCountryCode { get; set; }
        public string? IdNumber { get; set; }
        public string? PostalSuburb { get; set; }
        public bool? IsSacitizen { get; set; }
        public string? AppliedBy { get; set; }
    }
}
