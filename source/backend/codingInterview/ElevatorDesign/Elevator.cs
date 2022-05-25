using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.ElevatorDesign
{
    public class Elevator
    {
        public enum Direction { UP, DOWN };
        public enum Status { Idle, Active, OutOFOrder };
        public Button ElevatButton;
        public string ElevatorReference { get; set; }
        private int CurrentFloor { get; set; }

        public Elevator()
        {
            this.ElevatButton = new ElevatorButton();
        }

        

        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }

        private void CloseDoor()
        {

        }

        private void OpenDoor()
        {

        }

        private void SetAlarm()
        {

        }
    }
}
