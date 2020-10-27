using System;
using System.Collections.Generic;

namespace iOrgaoAPI.Models
{
    public partial class TbDoctor
    {
        public TbDoctor()
        {
            TbDonations = new HashSet<TbDonation>();
        }

        public int IdDoctor { get; set; }
        public int? IdPatient { get; set; }
        public int CrmDoctor { get; set; }
        public string EmailDoctor { get; set; }
        public string PasswordDoctor { get; set; }
        public string NameDoctor { get; set; }
        public string RgDoctor { get; set; }
        public string PhoneDoctor { get; set; }
        public DateTime? DateCreatedDoctor { get; set; }
        public DateTime? DateUpdatedDoctor { get; set; }

        public virtual TbPatient IdPatientNavigation { get; set; }
        public virtual ICollection<TbDonation> TbDonations { get; set; }
    }
}
