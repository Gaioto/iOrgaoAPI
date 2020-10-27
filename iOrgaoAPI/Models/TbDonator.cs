using System;
using System.Collections.Generic;

namespace iOrgaoAPI.Models
{
    public partial class TbDonator
    {
        public TbDonator()
        {
            TbDonations = new HashSet<TbDonation>();
        }

        public int IdDonator { get; set; }
        public int? IdAdress { get; set; }
        public int? IdOrgan { get; set; }
        public string NameDonator { get; set; }
        public string RgDonator { get; set; }
        public string CpfDonator { get; set; }
        public string PhoneDonator { get; set; }
        public string EmailDonator { get; set; }
        public string PasswordDonator { get; set; }
        public string GenreDonator { get; set; }
        public DateTime BirthdateDonator { get; set; }
        public double HeightDonator { get; set; }
        public double WeightDonator { get; set; }
        public string BloodTypeDonator { get; set; }
        public DateTime? DateCreatedDonator { get; set; }
        public DateTime? DateUpdatedDonator { get; set; }

        public virtual TbAdress IdAdressNavigation { get; set; }
        public virtual TbOrgan IdOrganNavigation { get; set; }
        public virtual ICollection<TbDonation> TbDonations { get; set; }
    }
}
