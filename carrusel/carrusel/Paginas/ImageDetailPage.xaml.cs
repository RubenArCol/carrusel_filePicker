namespace carrusel.Paginas;

public partial class ImageDetailPage : ContentPage
{
	public ImageDetailPage(ImageItem imagen)
    {
        InitializeComponent();
        BindingContext = imagen;
    }
}