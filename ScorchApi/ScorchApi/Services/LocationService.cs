using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ScorchApi.Interfaces;
using System.Device;
using System.Device.Location;
using ScorchApi.Models;

namespace ScorchApi.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _dbContext;
        public LocationService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<IList<Guid>> LocationsByDistance()
        {
            await _dbContext.SaveChangesAsync();
            return new List<Guid>();
        }

        private static double GetDistanceBetween(int sLatitude, int sLongitude, int eLatitude, int eLongitude)
        {
            var s = new GeoCoordinate(sLatitude, sLongitude);
            var e = new GeoCoordinate(eLatitude, eLongitude);

            return s.GetDistanceTo(e);
        }
    }
}