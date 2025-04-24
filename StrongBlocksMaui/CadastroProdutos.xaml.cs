namespace StrongBlocksMaui;

public partial class CadastroProdutos : ContentPage
{
	public CadastroProdutos()
	{
        InitializeComponent();

        Produto p = new Produto();
        Lista.ItemsSource = p.BuscaTodos();
    }

    private void Salvar_Clicked(object sender, EventArgs e)
    {
        Produto p = new Produto();
        p.tipo_insumo = EntryIsumo.Text;
        p.quantidade = int.Parse(EntryQuantidade.Text);
        p.Insere();

        Lista.ItemsSource = null;
        Lista.ItemsSource = p.BuscaTodos();
    }
}