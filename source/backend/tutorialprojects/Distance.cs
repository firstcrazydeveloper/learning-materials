using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProjects
{
    public class PetrolPump
    {
        public int Petrol { get; set; }
        public int Distance { get; set; }
        int printTour(PetrolPump[] arr, int n)
        {
            // Consider first petrol pump as a starting point
            int start = 0;
            int end = 1;

            int curr_petrol = arr[start].Petrol - arr[start].Distance;

            /* Run a loop while all petrol pumps are not visited.
              And we have reached first petrol pump again with 0 or more petrol */
            while (end != start || curr_petrol < 0)
            {
                // If curremt amount of petrol in truck becomes less than 0, then
                // remove the starting petrol pump from tour
                while (curr_petrol < 0 && start != end)
                {
                    // Remove starting petrol pump. Change start
                    curr_petrol -= arr[start].Petrol - arr[start].Distance;
                    start = (start + 1) % n;

                    // If 0 is being considered as start again, then there is no
                    // possible solution
                    if (start == 0)
                        return -1;
                }

                // Add a petrol pump to current tour
                curr_petrol += arr[end].Petrol - arr[end].Distance;

                end = (end + 1) % n;
            }

            // Return starting point
            return start;
        }

        public void Test()
        {
            PetrolPump[] arr = {new PetrolPump(){ Petrol= 4, Distance = 6}, new PetrolPump() { Petrol = 6, Distance = 5 },
                new PetrolPump(){ Petrol= 7, Distance = 3}, new PetrolPump(){ Petrol= 4, Distance = 5} };

            int n = arr.Length;
            int start = printTour(arr, n);
        }
    }
}
