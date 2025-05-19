namespace StrongBlocksMaui;

public partial class CadastroInsumo : ContentPage
{
	public CadastroInsumo()
	{
		InitializeComponent();
	}

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
        Produto p = new Produto();
        p.nome = EntryNome.Text;
        p.quantidade = int.Parse(EntryQuantidade.Text);
        p.tipo = "insumo";
        p.Insere();

        EntryNome.Text = "";
        EntryQuantidade.Text = "";
        
        await Shell.Current.GoToAsync("//ListagemInsumos");

    }

    /*
     
     
     */

}