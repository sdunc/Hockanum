using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockanum.Services
{
    public partial class Valve : ObservableObject
    {
        // how open is the valve 0=closed, 1=all open.
        // flowThrough = min (ValvePosition * pipe_cross_section, inflow)
        // https://www.khanacademy.org/science/physics/fluids/fluid-dynamics/a/what-is-volume-flow-rate#:~:text=A%20A%20is%20the%20cross%20sectional%20area%20of,the%20area%20A%20A%20is%20easy%20to%20determine.
        [ObservableProperty]
        private double valvePosition = 0;

        partial void OnValvePositionChanged(double value)
        {
            if (ValvePosition > 1) ValvePosition = 1;
            else if (ValvePosition < 0) ValvePosition = 0;
        }

        public void TurnValveLeft() { ValvePosition += 0.1; }
        
        public void TurnValveRight() { ValvePosition -= 0.1; }

    }
}
