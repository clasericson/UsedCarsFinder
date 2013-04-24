using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.ApplicationModel;
using System.IO;
using System.Net.Http;


namespace UsedCarsFinder.Data
{
    public sealed class MainDataSource
    {
        private static MainDataSource _mainDataSource = new MainDataSource();

        private ObservableCollection<CarGroup> _allGroups = new ObservableCollection<CarGroup>();
        public ObservableCollection<CarGroup> AllGroups
        {
            get { return this._allGroups; }
        }

        public static IEnumerable<CarGroup> GetGroups(string uniqueId)
        {
            if (!uniqueId.Equals("AllGroups")) throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");
            
            return _mainDataSource.AllGroups;
        }

        public static CarGroup GetGroup(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _mainDataSource.AllGroups.Where((group) => group.Id.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static Car GetCar(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _mainDataSource.AllGroups.SelectMany(group => group.Cars).Where((car) => car.Id.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public MainDataSource()
        {
            // Read the xml-file.
            GetData();
        }

        private async void GetData()
        {
            var url = "http://data.bytbil.com/select_car.cgi?look=rolfericsonfalun/xml&seller=rolfericsonborlange&seller=rolfericsonfalun&xmlimage=1&carsperpage=300&sort=time&sellertype=seller_all";
            var client = new HttpClient();
            Stream stream = await client.GetStreamAsync(url);
            XDocument usedCars = XDocument.Load(stream);

            var groupedCars = usedCars.Element("cars").Elements("car").Select(c =>
            {
                            int yearModel = -1;
                            int.TryParse(c.Element("yearmodel").Value, out yearModel);
                            int id = -1;
                            int.TryParse(c.Element("id").Value, out id);
                            int mileage = -1;
                            int.TryParse(c.Element("miles").Value, out mileage);
                            double priceSek = -1;
                            double.TryParse(c.Element("price-sek").Value, out priceSek);
                            double priceExtra = -1;
                            double.TryParse(c.Element("price-extra").Value, out priceExtra);
                            int vat = -1;
                            int.TryParse(c.Element("exkl_moms").Value, out vat);
                            int envir = -1;
                            int.TryParse(c.Element("environment").Value, out envir);
                            var images = c.Element("images").Elements("image").Where(i => i.Value.Contains(".jpg") || i.Value.Contains(".png")).Select(i => i.Value);
                            var thumbs = c.Element("thumbs").Elements("thumb").Where(i => i.Value.Contains(".jpg") || i.Value.Contains(".png")).Select(i => i.Value);

                            if (images.Any())
                            {

                            }

                           return new Car()
                               {
                                   Brand = c.Element("brand").Value,
                                   Model = c.Element("model").Value,
                                   ModelDescription = c.Element("modeldescription").Value,
                                   YearModel = yearModel,
                                   BodyType = c.Element("bodytype").Value,
                                   Color = c.Element("color").Value,
                                   FuelType = c.Element("fueltype").Value,
                                   GearBoxType = c.Element("gearboxtype").Value,
                                   //Id = id,
                                   FirstReg = c.Element("firstreg").Value,
                                   RegNo = c.Element("regno").Value,
                                   Mileage = mileage,
                                   PriceSek = priceSek,
                                   PriceExtra = priceExtra,
                                   ExclVAT = vat,
                                   Added = c.Element("added").Value,
                                   City = c.Element("city").Value,
                                   ContactId = c.Element("contactid").Value,
                                   Engine = c.Element("engine").Value,
                                   Environment = envir,
                                   Images = images,
                                   Thumbs = thumbs,
                                   Info = c.Element("info").Value,
                                   Phone = c.Element("phone").Value,
                                   HomePage = c.Element("homepage").Value,
                                   Fax = c.Element("fax").Value,
                                   Seller = c.Element("seller").Value
                               };
                            })
                            .GroupBy(c => c.Brand)
                            .OrderBy(c => c.Key);
            
            int j = 0;
            foreach (IGrouping<string, Car> g in groupedCars)
            {
                //ObservableCollection<Car> cars = new ObservableCollection<Car>(g.Select(c => c));
                var group = new CarGroup(string.Format("Group-{0}", j++), g.Key);
                foreach(Car c in g)
                {
                    c.Group = group;
                    group.Cars.Add(c);
                };
                AllGroups.Add(group);
            }                
        }
    }    
}
