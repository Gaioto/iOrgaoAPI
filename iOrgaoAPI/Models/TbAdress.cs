using System;
using System.Collections.Generic;

namespace iOrgaoAPI.Models
{
    public partial class TbAdress
    {
        public TbAdress()
        {
            TbDonators = new HashSet<TbDonator>();
            TbPatients = new HashSet<TbPatient>();
        }

        public int IdAdress { get; set; }
        public string StreetAdress { get; set; }
        public int NumberAdress { get; set; }
        public string ComplementAdress { get; set; }
        public string CityAdress { get; set; }
        public string ZipcodeAdress { get; set; }
        public string StateAdress { get; set; }
        public DateTime? DateCreatedAdress { get; set; }
        public DateTime? DateUpdatedAdress { get; set; }

        public virtual ICollection<TbDonator> TbDonators { get; set; }
        public virtual ICollection<TbPatient> TbPatients { get; set; }
    }
}
