using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthServices.Domain.Models
{
    public class VitalSign
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public double BodyMassIndex { get; set; }
    }
}
