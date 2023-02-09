using CherryBakewell.Database.Models;

namespace CherryBakewell.Web.Models
{
    public class AddCalculation
    {
        public double InputA { get; set; }
        public double InputB { get; set; }
        public Operator Operator { get; set; }
        public double Answer { get; set; }
    }
}
