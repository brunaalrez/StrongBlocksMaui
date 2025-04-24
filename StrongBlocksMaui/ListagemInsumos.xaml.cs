namespace StrongBlocksMaui;

public partial class ListagemInsumos : ContentPage
{
	public ListagemInsumos()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Produto produto = new Produto();
        Lista.ItemsSource = null;
        Lista.ItemsSource = produto.BuscaTodosInsumos();
    }

}