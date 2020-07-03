using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IAddressService
    {
        IReadOnlyCollection<AddressViewModel> GetAddresses();
        bool AddAddress();
    }
}
