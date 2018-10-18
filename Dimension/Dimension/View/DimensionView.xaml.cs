using Dimension.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dimension.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DimensionView : ContentPage
    {
        public DimensionView()
        {
            InitializeComponent();
            BindingContext = new DimensionViewModel();

        }
    }
}