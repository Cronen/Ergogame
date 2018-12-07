using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ergogame.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ergogame.student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopicDetails : ContentPage
    {
        TopicTask Task;
        public TopicDetails(TopicTask tt)
        {
            Task = tt; ;
            InitializeComponent();
            LV_Materials.ItemsSource = Task.Materials;
            LB_TopicName.Text = Task.Name;
            LB_Desc.Text = Task.Description;
        }
        public TopicDetails()
        {
            //This is only for development, remove for final product
            Task = GenerateDummyData();
            BindingContext = Task.Materials;
            InitializeComponent();
            LB_TopicName.Text = Task.Name;
            LB_Desc.Text = Task.Description;

        }
        private TopicTask GenerateDummyData()
        {

            return new TopicTask("Topic 1", DateTime.Now.AddDays(1));
        }

        private async void OnBack(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void MaterialTap(object sender, ItemTappedEventArgs e)
        {
            Material mat = (Material)e.Item;
            Device.OpenUri(new System.Uri(mat.URL));
        }
    }
}