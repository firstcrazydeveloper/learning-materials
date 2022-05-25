using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.ElevatorDesign
{
    public class ElevatorController
    {
        public List<Elevator> elevatorList;
        public int TotalFloor { get; set; }
        public Button FlrButton;

        public ElevatorController()
        {
            this.elevatorList = new List<Elevator>();
            this.FlrButton = new FloorButton();
        }

        public void AddFloorRequest(int floor)
        {
            this.FlrButton.PlaceRequest();
        }

        public void AddElevator(Elevator elevator)
        {
            this.elevatorList.Add(elevator);
        }

        public void ShutDownElevator()
        {

        }

        public void StartElevator()
        {

        }

        public void Reset()
        {

        }
    }
}
