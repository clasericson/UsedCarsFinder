using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCarsFinder.Common;

namespace UsedCarsFinder.Data
{
    public class Car : BindableBase
    {
        #region Public properties
        public string Id
        {
            get { return regno; }
        }

        private string regno;
        public string RegNo 
        {
            get { return regno; }
            set
            {
                this.SetProperty(ref this.regno, value);
            }
        }   

        private string brand;
        public  string Brand
        {
            get { return brand; }
            set
            {
                this.SetProperty(ref this.brand, value);
            }
        } 

        private string model;
        public  string Model
        {
            get { return model; }
            set
            {
                this.SetProperty(ref this.model, value);
            }
        } 

        private string modeldescription;
        public  string ModelDescription
        {
            get { return modeldescription; }
            set
            {
                this.SetProperty(ref this.modeldescription, value);
            }
        } 

        private int? yearmodel;
        public  int? YearModel
        {
            get { return yearmodel; }
            set
            {
                this.SetProperty(ref this.yearmodel, value);
            }
        } 

        private string firstreg;
        public  string FirstReg
        {
            get { return firstreg; }
            set
            {
                this.SetProperty(ref this.firstreg, value);
            }
        } 

        private int? mileage;
        public  int? Mileage
        {
            get { return mileage; }
            set
            {
                this.SetProperty(ref this.mileage, value);
            }
        } 

        private double? pricesek;
        public  double? PriceSek
        {
            get { return pricesek; }
            set
            {
                this.SetProperty(ref this.pricesek, value);
            }
        } 

        private double? priceextra;
        public  double? PriceExtra
        {
            get { return priceextra; }
            set
            {
                this.SetProperty(ref this.priceextra, value);
            }
        } 

        private string bodytype;
        public  string BodyType
        {
            get { return bodytype; }
            set
            {
                this.SetProperty(ref this.bodytype, value);
            }
        } 

        private string fax;
        public  string Fax
        {
            get { return fax; }
            set
            {
                this.SetProperty(ref this.fax, value);
            }
        } 

        private string color;
        public  string Color
        {
            get { return color; }
            set
            {
                this.SetProperty(ref this.color, value);
            }
        } 

        private string phone;
        public  string Phone
        {
            get { return phone; }
            set
            {
                this.SetProperty(ref this.phone, value);
            }
        } 

        private string homepage;
        public  string HomePage
        {
            get { return homepage; }
            set
            {
                this.SetProperty(ref this.homepage, value);
            }
        } 

        private string info;
        public  string Info
        {
            get { return info; }
            set
            {
                this.SetProperty(ref this.info, value);
            }
        } 

        private string gearboxtype;
        public  string GearBoxType
        {
            get { return gearboxtype; }
            set
            {
                this.SetProperty(ref this.gearboxtype, value);
            }
        } 

        private string fueltype;
        public  string FuelType
        {
            get { return fueltype; }
            set
            {
                this.SetProperty(ref this.fueltype, value);
            }
        } 

        private string seller;
        public  string Seller
        {
            get { return seller; }
            set
            {
                this.SetProperty(ref this.seller, value);
            }
        } 

        private string city;
        public string City 
        {
            get { return city; }
            set
            {
                this.SetProperty(ref this.city, value);
            }
        } 

        private string contactid;
        public  string ContactId
        {
            get { return contactid; }
            set
            {
                this.SetProperty(ref this.contactid, value);
            }
        } 

        private int? exclvat;
        public  int? ExclVAT
        {
            get { return exclvat; }
            set
            {
                this.SetProperty(ref this.exclvat, value);
            }
        } 

        private string added;
        public  string Added
        {
            get { return added; }
            set
            {
                this.SetProperty(ref this.added, value);
            }
        } 

        private int? environment;
        public  int? Environment
        {
            get { return environment; }
            set
            {
                this.SetProperty(ref this.environment, value);
            }
        } 

        private string engine;
        public string Engine 
        {
            get { return engine; }
            set
            {
                this.SetProperty(ref this.engine, value);
            }
        }

        public string MainImage { get { return Images != null && Images.Any() ? Images.First() : string.Empty; } }

        private IEnumerable<string> images;
        public  IEnumerable<string> Images
        {
            get { return images; }
            set
            {
                this.SetProperty(ref this.images, value);
            }
        } 

        private IEnumerable<string> thumbs;
        public  IEnumerable<string> Thumbs
        {
            get { return thumbs; }
            set
            {
                this.SetProperty(ref this.thumbs, value);
            }
        }

        private CarGroup group;
        public CarGroup Group
        {
            get { return group; }
            set
            {
                this.SetProperty(ref this.group, value);
            }
        }
        #endregion
    }
}
