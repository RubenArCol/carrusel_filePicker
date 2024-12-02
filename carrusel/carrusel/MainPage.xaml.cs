using System.Collections.ObjectModel;
using carrusel.Paginas;

namespace carrusel
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ImageItem> Images { get; set; } // lista de objetos para almacenar imagenes

        public MainPage()
        {
            InitializeComponent();

            Images = new ObservableCollection<ImageItem>
            {
                // imagenes con fecha de subida
                new ImageItem { ImagePath = "animal1.jpg", Description = "Tigre", UploadDate = DateTime.Now.AddDays(-10) }, 
                new ImageItem { ImagePath = "animal2.jpg", Description = "Leon", UploadDate = DateTime.Now.AddDays(-7) },
                new ImageItem { ImagePath = "animal3.jpg", Description = "Panda", UploadDate = DateTime.Now.AddDays(-5) },
                new ImageItem { ImagePath = "animal4.jpg", Description = "Lince", UploadDate = DateTime.Now.AddDays(-3) },
                new ImageItem { ImagePath = "animal5.jpg", Description = "Cebra", UploadDate = DateTime.Now.AddDays(-1) },
                new ImageItem { ImagePath = "animal6.jpg", Description = "Buitre", UploadDate = DateTime.Now.AddDays(-1) }
            };

            ListaImagenes.ItemsSource = Images; // añado las imagenes a la lista de objetos
        }

        private async void OnImageTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is ImageItem selectedItem)
            {
                await Navigation.PushAsync(new ImageDetailPage(selectedItem)); // lo agrego a la pila
            }
        }

        private async void OnAddImageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddImagePage(Images)); // espera a meterlo en la pila para actualizar
        }
    }
}