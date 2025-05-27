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
            await DisplayAlert("Erro", "Quantidade inválida. Digite um número inteiro.", "OK");
            return;
        }

        Produto p = new Produto();

        bool existe = p.ExisteProduto(nomeProduto);
        if (!existe)
        {
            await DisplayAlert("Produto não encontrado", $"O produto '{nomeProduto}' não existe no banco de dados.", "OK");
            return;
        }

        int id_produto = nomeProduto.ToLower() switch
        {
            "bloco a" => 4,
            "meio bloco a" => 5,
            "canaleta a" => 6,
            "meia canaleta a" => 7,
            "bloco b" => 8,
            "meio bloco b" => 9,
            "canaleta b" => 10,
            "meia canaleta b" => 11,
            "bloco c" => 12,
            "meio bloco c" => 13,
            "canaleta c" => 14,
            "meia canaleta c" => 15,
            _ => 0
        };

        if (id_produto == 0)
        {
            await DisplayAlert("Erro", $"O nome do produto '{nomeProduto}' não é válido.", "OK");
            return;
        }

        p.id = id_produto;
        p.nome = nomeProduto;
        p.quantidade = quantidade;
        p.tipo = "Produto";
        p.Atualiza();

        // Limpa os campos após salvar
        EntryNomeProduto.Text = string.Empty;
        EntryQuantidade.Text = string.Empty;

        await DisplayAlert("Sucesso", "Produto atualizado com sucesso.", "OK");

        await Shell.Current.GoToAsync("//ListagemProdutos");
    }
}
