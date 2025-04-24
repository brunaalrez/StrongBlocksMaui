namespace StrongBlocksMaui;

public partial class CadastroProdutos : ContentPage
{
	public CadastroProdutos()
	{
        InitializeComponent();

    }

    private void Salvar_Clicked(object sender, EventArgs e)
    {
        Produto p = new Produto();
        p.tipo_insumo = EntryIsumo.Text;
        p.quantidade = int.Parse(EntryQuantidade.Text);
        p.Insere();

        
    }
}