using Microsoft.Extensions.Configuration;

namespace Transport_ly.Auxiliaries
{
    public static class Configuration
    {

        public static readonly ConfigurationSettings Settings;
        static Configuration()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfiguration config = configurationBuilder.AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

            Settings = config.GetRequiredSection("Settings").Get<ConfigurationSettings>();
        }
    }

    //------------------------------------

    #region Aux_classes
    public class ConfigurationSettings
    {

        public NestedDataLoad DataLoad { get; set; }

        public NestedModels Model { get; set; }

    }

    public class NestedModels
    {
        public OrderDefaults Order { get; set; }
        public FlightScheduleDefaults FlightSchedule { get; set; }


        public class OrderDefaults
        { 
            public string DefaultOrigin { get; set; }
            public int DefaultVolume { get; set; }
            public int DefaultPriorityStart { get; set; }
        }

        public class FlightScheduleDefaults
        {
            public string DefaultOrigin { get; set; }
            public int DefaultFlightStart { get; set; }

            public int DefaultStartDay { get; set; }

            public int DefaultCapacity { get; set; }
        }
    }

    public class NestedDataLoad
    { 
        public DataLoad FlightSchedule  { get; set; }
        public DataLoad Order { get; set; }

        public class DataLoad
        {
            public string Source { get; set; }
            public string Value { get; set; }
        }
    }




    #endregion
}
