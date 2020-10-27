using System;
using System.Collections.Generic;

namespace iOrgaoAPI.Models
{
    public partial class TbPatient
    {
        public TbPatient()
        {
            TbDoctors = new HashSet<TbDoctor>();
            TbDonations = new HashSet<TbDonation>();
        }

        public int IdPatient { get; set; }
        public int? IdAdress { get; set; }
        public int? IdOrgan { get; set; }
        public string NamePatient { get; set; }
        public string RgPatient { get; set; }
        public string CpfPatient { get; set; }
        public string PhonePatient { get; set; }
        public string EmailPatient { get; set; }
        public string PasswordPatient { get; set; }
        public string GenrePatient { get; set; }
        public DateTime BirthdatePatient { get; set; }
        public double HeightPatient { get; set; }
        public double WeightPatient { get; set; }
        public string BloodTypePatient { get; set; }
        public DateTime? DateCreatedPatient { get; set; }
        public DateTime? DateUpdatedPatient { get; set; }

        public virtual TbAdress IdAdressNavigation { get; set; }
        public virtual TbOrgan IdOrganNavigation { get; set; }
        public virtual ICollection<TbDoctor> TbDoctors { get; set; }
        public virtual ICollection<TbDonation> TbDonations { get; set; }
    }
}
