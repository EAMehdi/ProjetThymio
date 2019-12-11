using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThymioWPFApplication.ViewModels.DemonstrationViewModels
{
    class SensorViewModel :BaseViewModel
    {
        private ObservableCollection<bool> sensorList;
        public ObservableCollection<bool> SensorList
        {
            get { return sensorList; }
        }

        public bool Val
        {
            get { return sensorList[0]; }
        }

        public SensorViewModel()
        {
            sensorList = new ObservableCollection<bool>();
            for (int i = 0; i < 6; i++)
                sensorList.Add(false);
            
        }

    }
}
