using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Domain.Entities
{
    public class FacultyCulture : Entity
    {
        public int Id { get; set; }
        public string Culture { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
