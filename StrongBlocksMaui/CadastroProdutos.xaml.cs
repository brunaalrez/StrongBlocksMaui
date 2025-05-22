namespace StrongBlocksMaui;

public partial class CadastroProdutos : ContentPage
{
	public CadastroProdutos()
	{
        InitializeComponent();

    }

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
        string nomeProduto = EntryNomeProduto.Text?.Trim() ?? "";
        string quantidadeTexto = EntryQuantidade.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(nomeProduto) || string.IsNullOrWhiteSpace(quantidadeTexto))
        {
            await DisplayAlert("Erro", "Preencha todos os campos.", "OK");
            return;
        }

        if (!int.TryParse(quantidadeTexto, out int quantidade))
        {
            await DisplayAlert("Erro", "Quantidade inv�lida.", "OK");
            return;
        }

        Produto p = new Produto();

        bool existe = p.ExisteProduto(nomeProduto);
        if (!existe)
        {
            await DisplayAlert("Produto n�o encontrado", $"O produto '{nomeProduto}' n�o existe no banco de dados.", "OK");
            return;
        }

        p.nome = nomeProduto;
        p.quantidade = quantidade;
        p.tipo = "produto";
        p.Atualiza();

        // Limpa os campos ap�s salvar
        EntryNomeProduto.Text = string.Empty;
        EntryQuantidade.Text = string.Empty;

        await Shell.Current.GoToAsync("//ListagemProdutos");

    }
}