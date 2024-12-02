using System.Collections.ObjectModel;

namespace carrusel.Paginas;

public partial class AddImagePage : ContentPage
{
    private ObservableCollection<ImageItem> _images; // lista de imagenes (en teoría se  actualiza sola??????)
    private string _imagenSeleccionadaPath; // ruta de la imagen

    public AddImagePage(ObservableCollection<ImageItem> images)
    {
        InitializeComponent();
        _images = images;

        // fecha actual
        UploadDatePicker.Date = DateTime.Now;
    }

    private async void OnSelectImageClicked(object sender, EventArgs e)
    {
        try
        {
            // selecciono archivo
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Selecciona una imagen",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                _imagenSeleccionadaPath = result.FullPath;

                // imagen seleccionada
                imagenSeleccionada.Source = ImageSource.FromFile(_imagenSeleccionadaPath);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo seleccionar la imagen: {ex.Message}", "OK");
        }
    }

    private async void OnAddImageClicked(object sender, EventArgs e)
    {
        // comprobaciones
        if (string.IsNullOrWhiteSpace(_imagenSeleccionadaPath))
        {
            await DisplayAlert("Error", "Debes seleccionar una imagen antes de continuar.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(DescriptionEntry.Text))
        {
            await DisplayAlert("Error", "Debes ingresar una descripción para la imagen.", "OK");
            return;
        }

        // creo una nueva "imagen"
        var newImage = new ImageItem
        {
            ImagePath = _imagenSeleccionadaPath, // Ruta del archivo seleccionado
            Description = DescriptionEntry.Text, // desc
            UploadDate = UploadDatePicker.Date // fecha actual
        };

        // añado imagen a la lista
        _images.Add(newImage);

        // regreso a la pagina de la lista
        await Navigation.PopAsync();
    }
}
