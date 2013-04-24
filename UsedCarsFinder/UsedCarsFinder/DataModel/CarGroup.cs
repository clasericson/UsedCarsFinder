using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCarsFinder.Common;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace UsedCarsFinder.Data
{
    public class CarGroup : BindableBase
    {
        #region Public properties
        private string id;
        public string Id
        {
            get { return id; }
            set { this.SetProperty(ref this.id, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { this.SetProperty(ref this.title, value); }
        }

        private ObservableCollection<Car> cars = new ObservableCollection<Car>();
        public ObservableCollection<Car> Cars
        {
            get { return this.cars; }
            // set { this.SetProperty(ref this.cars, value); }
        }

        private ObservableCollection<Car> topCars = new ObservableCollection<Car>();
        public ObservableCollection<Car> TopCars
        {
            get { return this.topCars; }
        }

        public int? NumberOfCars
        {
            get
            {
                if (cars == null || !cars.Any())
                    return 0;
                else
                    return cars.Count();
            }
        }
        #endregion

        #region Constructor
        public CarGroup(string id, String title)
        {
            Id = id;
            Title = title;
            Cars.CollectionChanged += CarsCollectionChanged;
        }
        #endregion

        #region Event handlers
        private void CarsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Provides a subset of the full items collection to bind to from a GroupedItemsPage
            // for two reasons: GridView will not virtualize large items collections, and it
            // improves the user experience when browsing through groups with large numbers of
            // items.
            //
            // A maximum of 12 items are displayed because it results in filled grid columns
            // whether there are 1, 2, 3, 4, or 6 rows displayed

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewStartingIndex < 12)
                    {
                        TopCars.Insert(e.NewStartingIndex,Cars[e.NewStartingIndex]);
                        if (TopCars.Count > 12)
                        {
                            TopCars.RemoveAt(12);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    if (e.OldStartingIndex < 12 && e.NewStartingIndex < 12)
                    {
                        TopCars.Move(e.OldStartingIndex, e.NewStartingIndex);
                    }
                    else if (e.OldStartingIndex < 12)
                    {
                        TopCars.RemoveAt(e.OldStartingIndex);
                        TopCars.Add(Cars[11]);
                    }
                    else if (e.NewStartingIndex < 12)
                    {
                        TopCars.Insert(e.NewStartingIndex, Cars[e.NewStartingIndex]);
                        TopCars.RemoveAt(12);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldStartingIndex < 12)
                    {
                        TopCars.RemoveAt(e.OldStartingIndex);
                        if (Cars.Count >= 12)
                        {
                            TopCars.Add(Cars[11]);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.OldStartingIndex < 12)
                    {
                        TopCars[e.OldStartingIndex] = Cars[e.OldStartingIndex];
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    TopCars.Clear();
                    while (TopCars.Count < Cars.Count && TopCars.Count < 12)
                    {
                        TopCars.Add(Cars[TopCars.Count]);
                    }
                    break;
            }
            this.OnPropertyChanged("NumberOfCars");
        }
        #endregion

        #region General model methods
        public override string ToString()
        {
            return this.Title;
        }
        #endregion
    }
}
