
using Transport_ly.Auxiliaries;
using Transport_ly.Data.Interfaces;
using Transport_ly.Model;
using System.Text.Json;
using Transport_ly.Model.DTO;

namespace Transport_ly.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public readonly string DefaultOrigin        = Configuration.Settings.Model.Order.DefaultOrigin;
        public readonly int DefaultVolume           = Configuration.Settings.Model.Order.DefaultVolume;
        public readonly string FilePath             = Configuration.Settings.DataLoad.Order.Value;
        public readonly int DefaultPriorityStart    = Configuration.Settings.Model.Order.DefaultPriorityStart;


        //Get
        public async Task<IEnumerable<Order>> GetCollectionAsync(OrderRepositoryParameters param)
        {
            IEnumerable<Order> dataSource = await ReadDataAsync();
            IQueryable<Order> query = dataSource.AsQueryable();

            if (param == null) { return dataSource; }


            if (param.OrderIdentifier != null) { query = query.Where(x => x.OrderIdentifier.Equals(param.OrderIdentifier)); }

            if (param.Origin != null) { query = query.Where(x => x.Origin.Equals(param.Origin)); }

            if (param.Destination != null) { query = query.Where(x => x.Destination.Equals(param.Destination)); }

            if (param.Volume != null) { query = query.Where(x => x.Volume == param.Volume); }


            return query.ToList();
        }
        

        //------------------------

        private async Task<IEnumerable<Order>> ReadDataAsync()
        {
            List<Order> returnObj = new();
            string jsonFile = await File.ReadAllTextAsync(FilePath);


            Dictionary<string, OrderJson> dic = JsonSerializer.Deserialize<Dictionary<string, OrderJson>>(jsonFile);

            int priority = DefaultPriorityStart;
            foreach ( var (key,value) in dic )
            {
                returnObj.Add(new() { OrderIdentifier = key, Origin = DefaultOrigin, Destination = value.Destination, Volume = DefaultVolume , Priority = priority++ } );
            }

            return returnObj;
        }


    }


    //--------------------------------


    public class OrderRepositoryParameters
    {
        public string OrderIdentifier { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int? Volume { get; set; }
    }


}
