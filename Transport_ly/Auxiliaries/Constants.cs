namespace Transport_ly.Auxiliaries
{
    public static class Constants
    {
        public static class FlightFreightConsts
        {
            public static readonly string NotScheduled = "not scheduled";
        }

        public static class LocationsConsts
        {

            public static readonly string YYZ = "YYZ";
            public static readonly string YYC = "YYC";
            public static readonly string YVR = "YVR";
            public static readonly string YUL = "YUL";

            public static readonly Dictionary<string, string> Locations = new() 
            { 
                { YYZ, "Toronto" } ,
                { YYC, "Calgary" } ,
                { YVR, "Vancouver" } ,
                { YUL, "Montreal" }
            };



            public static readonly string LocationError = "LOCATION NOT DEFINED";
        }
    }
}
