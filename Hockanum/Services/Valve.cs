using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockanum.Services
{
    public class Valve
    {
        // how open is the valve 0=closed, 1=all open.
        // flowThrough = min (ValvePosition * pipe_cross_section, inflow)
        // https://www.khanacademy.org/science/physics/fluids/fluid-dynamics/a/what-is-volume-flow-rate#:~:text=A%20A%20is%20the%20cross%20sectional%20area%20of,the%20area%20A%20A%20is%20easy%20to%20determine.
        private double valvePosition = 0;
        public double ValvePosition 
        {
            get => valvePosition;
            set
            {
                if (value < 0) valvePosition = 0;
                else if (value > 1) valvePosition = 1;
                else valvePosition = value;
            }
        }

        public void TurnValveLeft() { ValvePosition -= 0.1; }
        
        public void TurnValveRight() { ValvePosition -= 0.1; }

    }
}
