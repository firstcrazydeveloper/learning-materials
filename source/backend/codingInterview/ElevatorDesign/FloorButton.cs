using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.ElevatorDesign
{
    public class FloorButton : Button
    {
        public Elevator.Direction Direction { get; set; }

        public FloorButton()
        {
            this.request = new ElevatorRequest();
        }
        public override void PlaceRequest()
        {
            throw new NotImplementedException();
        }
    }
}
