using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.ElevatorDesign
{
    public abstract class Button
    {
        public bool Indicator { get; set; }
        public ElevatorRequest request;
        public void Illuminate()
        {

        }

        public void DoNotIlluminate()
        {

        }

        public abstract void PlaceRequest();
        
    }
}
