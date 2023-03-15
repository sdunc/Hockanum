using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hockanum.Models
{
    public partial class CylindricalTank : ObservableObject
    {
        /// <summary> Meters. Distance from the center of the tank to the edge of the tank. </summary>
        public double Radius { get; }
        
        /// <summary> Meters. Distance from the base of the tank to the top of the tank. </summary>
        public double Height { get; }

        /// <summary> Meters^3. Total volume of the cylindrical tank. </summary>
        public double TotalVolume { get; }

        [ObservableProperty]
        private double filledVolume;

        partial void OnFilledVolumeChanged(double value)
        {
            if (FilledVolume > TotalVolume) FilledVolume = TotalVolume;
            else if (FilledVolume < 0) FilledVolume = 0;
        }

        public CylindricalTank(double radius, double height)
        {
            Radius = radius;
            Height = height;
            TotalVolume = Math.PI * radius * radius * height;
        }

    }
}
