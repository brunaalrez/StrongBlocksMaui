namespace StrongBlocksMaui;

public partial class ListagensProdutos : ContentPage
{
	public ListagensProdutos()
	{
		InitializeComponent();

        Produto p = new Produto();
        Lista.ItemsSource = null;
        Lista.ItemsSource = p.BuscaTodos();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Produto p = new Produto();
        Lista.ItemsSource = null;
        Lista.ItemsSource = p.BuscaTodos();
    }
}