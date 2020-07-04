using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface ILocationsService
    {
        IReadOnlyCollection<AddressViewModel> GetLocations();
        bool AddLocation();
    }
}
