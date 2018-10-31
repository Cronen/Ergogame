using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ergogame.student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public TaskDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new TaskDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class TaskDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<TaskDetailPageMenuItem> MenuItems { get; set; }
            
            public TaskDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<TaskDetailPageMenuItem>(new[]
                {
                    new TaskDetailPageMenuItem { Id = 0, Title = "Page 1" },
                    new TaskDetailPageMenuItem { Id = 1, Title = "Page 2" },
                    new TaskDetailPageMenuItem { Id = 2, Title = "Page 3" },
                    new TaskDetailPageMenuItem { Id = 3, Title = "Page 4" },
                    new TaskDetailPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}