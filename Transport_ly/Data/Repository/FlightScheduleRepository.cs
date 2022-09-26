using Transport_ly.Auxiliaries;
using Transport_ly.Data.Interfaces;
using Transport_ly.Model;

using Consts = Transport_ly.Auxiliaries.Constants.LocationsConsts;

namespace Transport_ly.Data.Repository
{

    public class FlightScheduleRepository : IFlightScheduleRepository
    {

        public readonly int FlightCounter       = Configuration.Settings.Model.FlightSchedule.DefaultFlightStart;
        public readonly string DefaultDeparture = Configuration.Settings.Model.FlightSchedule.DefaultOrigin;
        public readonly int DefaultStartDay     = Configuration.Settings.Model.FlightSchedule.DefaultStartDay;
        public readonly int DefaultCapacity     = Configuration.Settings.Model.FlightSchedule.DefaultCapacity;
        //--------------------------------------------

        //Get

        public IEnumerable<FlightSchedule> GetCollection(FlightScheduleRepositoryParameters param) 
        {
            IEnumerable<FlightSchedule> dataSource = GenerateData();
            IQueryable<FlightSchedule> query = dataSource.AsQueryable();

            if (param == null) { return dataSource; }


            if (param.FlightNum != null) { query = query.Where(x => x.FlightNum == param.FlightNum); }

            if (param.Departure != null) { query = query.Where(x => x.Departure.Equals(param.Departure)); }

            if (param.Arrival != null) { query = query.Where(x => x.Arrival.Equals(param.Arrival)); }

            if (param.Day != null)  { query = query.Where(x => x.Day == param.Day); }

            if (param.IsReturnFlight != null) { query = query.Where(x => x.IsReturnFlight == param.IsReturnFlight); }


            return query.ToList();
        }



        //---------------
        private IEnumerable<FlightSchedule> GenerateData(bool generateReturnflight = false)
        {
            List<FlightSchedule> returnObj = new();

            int flightCnt = FlightCounter;
            int day = DefaultStartDay;

            //-------------------------------------------
            //Day 1
            returnObj.Add(new() { FlightNum = flightCnt++, Departure = DefaultDeparture, Arrival = Consts.YYZ, Day = day, Capacity = DefaultCapacity, IsReturnFlight = false });
            returnObj.Add(new() { FlightNum = flightCnt++, Departure = DefaultDeparture, Arrival = Consts.YYC, Day = day, Capacity = DefaultCapacity, IsReturnFlight = false });
            returnObj.Add(new() { FlightNum = flightCnt++, Departure = DefaultDeparture, Arrival = Consts.YVR, Day = day, Capacity = DefaultCapacity, IsReturnFlight = false });
            //---
            //return flights
            if (generateReturnflight == true)
            {
                returnObj.Add(new() { FlightNum = flightCnt++, Departure = Consts.YYZ, Arrival = DefaultDeparture, Day = day, Capacity = DefaultCapacity, IsReturnFlight = true });
                returnObj.Add(new() { FlightNum = flightCnt++, Departure = Consts.YYC, Arrival = DefaultDeparture, Day = day, Capacity = DefaultCapacity, IsReturnFlight = true });
                returnObj.Add(new() { FlightNum = flightCnt++, Departure = Consts.YVR, Arrival = DefaultDeparture, Day = day, Capacity = DefaultCapacity, IsReturnFlight = true });
            }
            //-------------------------------------------
            //Day 2
            day++;
            returnObj.Add(new() { FlightNum = flightCnt++, Departure = DefaultDeparture, Arrival = Consts.YYZ, Day = day, Capacity = DefaultCapacity, IsReturnFlight = false });
            returnObj.Add(new() { FlightNum = flightCnt++, Departure = DefaultDeparture, Arrival = Consts.YYC, Day = day, Capacity = DefaultCapacity, IsReturnFlight = false });
            returnObj.Add(new() { FlightNum = flightCnt++, Departure = DefaultDeparture, Arrival = Consts.YVR, Day = day, Capacity = DefaultCapacity, IsReturnFlight = false });
            //---
            //return flights
            if (generateReturnflight == true)
            {
                returnObj.Add(new() { FlightNum = flightCnt++, Departure = Consts.YYZ, Arrival = DefaultDeparture, Day = day, Capacity = DefaultCapacity, IsReturnFlight = true });
                returnObj.Add(new() { FlightNum = flightCnt++, Departure = Consts.YYC, Arrival = DefaultDeparture, Day = day, Capacity = DefaultCapacity, IsReturnFlight = true });
                returnObj.Add(new() { FlightNum = flightCnt++, Departure = Consts.YVR, Arrival = DefaultDeparture, Day = day, Capacity = DefaultCapacity, IsReturnFlight = true });
            }
            //-------------------------------------------


            return returnObj;

        }


    }

    //-----------------------------------------------------------
    //class FlightScheduleRepository common parameters
    public class FlightScheduleRepositoryParameters
    {
        public int? FlightNum { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int? Day { get; set; }
        public bool? IsReturnFlight { get; set; }
    }

}
