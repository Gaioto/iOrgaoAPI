using System;
using System.Collections.Generic;

namespace iOrgaoAPI.Models
{
    public partial class TbDonation
    {
        public int IdDonation { get; set; }
        public int? IdDonator { get; set; }
        public int? IdPatient { get; set; }
        public int? IdDoctor { get; set; }
        public string DsDonation { get; set; }
        public DateTime? DateCreatedDonation { get; set; }
        public DateTime? DateUpdatedDonation { get; set; }

        public virtual TbDoctor IdDoctorNavigation { get; set; }
        public virtual TbDonator IdDonatorNavigation { get; set; }
        public virtual TbPatient IdPatientNavigation { get; set; }
    }
}
