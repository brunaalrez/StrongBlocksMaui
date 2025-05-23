namespace StrongBlocksMaui;

public partial class RemoverProduto : ContentPage
{
    public RemoverProduto()
    {
        InitializeComponent();
    }

    private async void RemoveProduto_Clicked(object sender, EventArgs e)
    {
        string? nomeProdutoRaw = EntryNome.Text?.Trim();
        string? quantidadeProdutoRaw = EntryQuantidade.Text?.Trim();

        if (string.IsNullOrWhiteSpace(nomeProdutoRaw) || string.IsNullOrWhiteSpace(quantidadeProdutoRaw))
        {
            await DisplayAlert("Erro", "Preencha todos os campos.", "OK");
            return;
        }

        string nomeProduto = nomeProdutoRaw!;
        string quantidadeProduto = quantidadeProdutoRaw!;

        if (!int.TryParse(quantidadeProduto, out int quantidadeRemover) || quantidadeRemover <= 0)
        {
            await DisplayAlert("Erro", "Quantidade inválida.", "OK");
            return;
        }

        Produto p = new Produto();

        bool existe = p.ExisteProduto(nomeProduto);
        if (!existe)
        {
            await DisplayAlert("Erro", $"O produto '{nomeProduto}' não existe.", "OK");
            return;
        }

        int quantidadeAtual = p.BuscaQuantidadeProduto(nomeProduto);

        if (quantidadeRemover > quantidadeAtual)
        {
            await DisplayAlert("Erro", $"Quantidade insuficiente no estoque. Atualmente há {quantidadeAtual}.", "OK");
            return;
        }

        bool confirmar = await DisplayAlert("Confirmação",
            $"Deseja remover {quantidadeRemover} unidade(s) do produto '{nomeProduto}'?",
            "Sim", "Não");

        if (!confirmar) return;

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
        p.quantidade = quantidadeRemover;
        p.RemoverQuantidadeProduto(); // Nova função que subtrai

        await DisplayAlert("Sucesso", $"Removido {quantidadeRemover} do produto '{nomeProduto}'.", "OK");

        EntryNome.Text = "";
        EntryQuantidade.Text = "";

        await Shell.Current.GoToAsync("//ListagemProdutos");
    }
}
