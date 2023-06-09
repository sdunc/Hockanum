﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DAQLib;
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
        private readonly DataService dataservice;

        [ObservableProperty]
        private TimeSpan refreshPeriod;

        [ObservableProperty]
        private CylindricalTank tank = new CylindricalTank(1, 3);

        [ObservableProperty]
        private Valve outflowValve = new();

        [RelayCommand]
        private void AddCubicMeter() { Tank.FilledVolume += 1; }

        [RelayCommand]
        private void RemoveCubicMeter() { Tank.FilledVolume -= 1; }

        [RelayCommand]
        private void TurnValveLeft() { outflowValve.TurnValveLeft(); }

        [RelayCommand]
        private void TurnValveRight() { outflowValve.TurnValveRight(); }

        public MainViewModel(DataService dataService)
        {
            dataservice = dataService;
            dataservice.NewData += Dataservice_NewData;
        }

        private void Dataservice_NewData(object? sender, EventArgs e)
        {
            Tank.FilledVolume += (1 - outflowValve.ValvePosition); // 1 M^3 inflow each second
            RefreshPeriod = dataservice.RefreshPeriod;
        }
    }
}
