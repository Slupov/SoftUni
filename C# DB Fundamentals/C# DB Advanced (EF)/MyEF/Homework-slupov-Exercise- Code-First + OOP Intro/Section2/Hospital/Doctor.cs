using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2.Hospital
{
    class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public int VisitationId { get; set; }
        public HashSet<Visitation> Visitations { get; set; }

    }
}
