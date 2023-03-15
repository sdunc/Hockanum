using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hockanum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockanum.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private CylindricalTank equalizationTank = new CylindricalTank(1, 3);

        [RelayCommand]
        private void AddCubicMeter() { equalizationTank.FilledVolume += 1; }

        [RelayCommand]
        private void RemoveCubicMeter() { equalizationTank.FilledVolume -= 1; }

    }
}
