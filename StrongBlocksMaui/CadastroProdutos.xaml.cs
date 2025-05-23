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
            await DisplayAlert("Erro", "Quantidade inválida.", "OK");
            return;
        }

        Produto p = new Produto();

        bool existe = p.ExisteProduto(nomeProduto);
        if (!existe)
        {
            await DisplayAlert("Produto não encontrado", $"O produto '{nomeProduto}' não existe no banco de dados.", "OK");
            return;
        }

        int id_produto = 1;
        if (nomeProduto.ToLower() == "bloco a")
            id_produto = 4;
        if (nomeProduto.ToLower() == "meio bloco a")
            id_produto = 5;
        if (nomeProduto.ToLower() == "canaleta a")
            id_produto = 6;
        if (nomeProduto.ToLower() == "meia canaleta a")
            id_produto = 7;
        if (nomeProduto.ToLower() == "bloco b")
            id_produto = 8;
        if (nomeProduto.ToLower() == "meio bloco b")
            id_produto = 9;
        if (nomeProduto.ToLower() == "canaleta b")
            id_produto = 10;
        if (nomeProduto.ToLower() == "meia canaleta b")
            id_produto = 11;
        if (nomeProduto.ToLower() == "bloco c")
            id_produto = 12;
        if (nomeProduto.ToLower() == "meio bloco c")
            id_produto = 13;
        if (nomeProduto.ToLower() == "canaleta c")
            id_produto = 14;
        if (nomeProduto.ToLower() == "meia canaleta c")
            id_produto = 15;

        p.id = id_produto;
        p.nome = nomeProduto;
        p.quantidade = quantidade;
        p.tipo = "Produto";
        p.Atualiza();

        // Limpa os campos após salvar
        EntryNomeProduto.Text = string.Empty;
        EntryQuantidade.Text = string.Empty;

        await Shell.Current.GoToAsync("//ListagemProdutos");

    }
}