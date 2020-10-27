using System;
using System.Collections.Generic;

namespace iOrgaoAPI.Models
{
    public partial class TbOrgan
    {
        public TbOrgan()
        {
            TbDonators = new HashSet<TbDonator>();
            TbPatients = new HashSet<TbPatient>();
        }

        public int IdOrgan { get; set; }
        public string NameOrgan { get; set; }
        public double HeightOrgan { get; set; }
        public double WeightOrgan { get; set; }
        public int AgeOrgan { get; set; }
        public string GenderOrgan { get; set; }
        public string ConditionOrgan { get; set; }
        public string DescriptionOrgan { get; set; }

        public virtual ICollection<TbDonator> TbDonators { get; set; }
        public virtual ICollection<TbPatient> TbPatients { get; set; }
    }
}
