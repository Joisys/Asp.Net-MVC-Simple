using System.Collections.Generic;
using Asp.Net_MVC_Simple.Models;

namespace Asp.Net_MVC_Simple.Data
{
    public static class TestData
    {
        public static List<LocationViewModel> LocationData()
        {
            return new List<LocationViewModel>
            {
                new LocationViewModel {Id = 1, Title = "London"},
                new LocationViewModel {Id = 2, Title = "Cardiff"},
                new LocationViewModel {Id = 3, Title = "Cochin"}
            };
        }
    }
}