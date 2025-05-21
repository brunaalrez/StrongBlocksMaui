namespace StrongBlocksMaui;

public partial class RemoverProduto : ContentPage
{
	public RemoverProduto()
	{
		InitializeComponent();
	}

    private async void RemoveProduto_Clicked(object sender, EventArgs e)
    {
        string nomeProduto = EntryNome.Text?.Trim();
        string quantidadeProduto = EntryQuantidade.Text?.Trim();

        if (string.IsNullOrWhiteSpace(nomeProduto) || string.IsNullOrWhiteSpace(quantidadeProduto))
        {
            await DisplayAlert("Erro", "Preencha todos os campos.", "OK");
            return;
        }

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

        p.nome = nomeProduto;
        p.quantidade = quantidadeRemover;
        p.RemoverQuantidadeProduto(); // Nova função que subtrai

        await DisplayAlert("Sucesso", $"Removido {quantidadeRemover} do produto '{nomeProduto}'.", "OK");

        EntryNome.Text = "";
        EntryQuantidade.Text = "";

        await Shell.Current.GoToAsync("//ListagemProdutos");
    }
}