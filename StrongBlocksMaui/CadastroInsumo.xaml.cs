namespace StrongBlocksMaui
{
    public CadastroInsumo()
    {
        InitializeComponent();

    
    }

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
        Produto p = new Produto();
        p.tipo_insumo = EntryNome.Text;
        p.quantidade = int.Parse(EntryQuantidade.Text);
        p.fornecedor = EntryFornecedor.Text;
        p.tipo_produto = "insumo";
        p.Insere();

        EntryNome.Text = "";
        EntryQuantidade.Text = "";
        EntryFornecedor.Text = "";

        await Shell.Current.GoToAsync("//ListagemInsumos");

    }
}
