namespace StrongBlocksMaui;

public partial class RemoverInsumo : ContentPage
{
    public RemoverInsumo()
    {
        InitializeComponent();
    }

    private async void Remover_Clicked(object sender, EventArgs e)
    {
        string? nomeInsumoRaw = EntryNome.Text?.Trim();
        string? quantidadeTextoRaw = EntryQuantidade.Text?.Trim();

        if (string.IsNullOrWhiteSpace(nomeInsumoRaw) || string.IsNullOrWhiteSpace(quantidadeTextoRaw))
        {
            await DisplayAlert("Erro", "Preencha todos os campos.", "OK");
            return;
        }

        string nomeInsumo = nomeInsumoRaw!;
        string quantidadeTexto = quantidadeTextoRaw!;

        if (!int.TryParse(quantidadeTexto, out int quantidadeRemover) || quantidadeRemover <= 0)
        {
            await DisplayAlert("Erro", "Quantidade inválida.", "OK");
            return;
        }

        Produto p = new Produto();

        bool existe = p.ExisteInsumo(nomeInsumo);
        if (!existe)
        {
            await DisplayAlert("Erro", $"O insumo '{nomeInsumo}' não existe.", "OK");
            return;
        }

        int quantidadeAtual = p.BuscaQuantidade(nomeInsumo);

        if (quantidadeRemover > quantidadeAtual)
        {
            await DisplayAlert("Erro", $"Quantidade insuficiente no estoque. Atualmente há {quantidadeAtual}.", "OK");
            return;
        }

        bool confirmar = await DisplayAlert("Confirmação",
            $"Deseja remover {quantidadeRemover} unidade(s) do insumo '{nomeInsumo}'?",
            "Sim", "Não");

        if (!confirmar) return;

        int id_produto = 1;
        if (nomeInsumo.ToLower() == "areia")
            id_produto = 1;
        if (nomeInsumo.ToLower() == "cimento")
            id_produto = 2;
        if (nomeInsumo.ToLower() == "po de pedra")
            id_produto = 3;

        p.id = id_produto;
        p.nome = nomeInsumo;
        p.quantidade = quantidadeRemover;
        p.tipo = "Insumo";
        p.RemoverQuantidade(); // Nova função que subtrai

        await DisplayAlert("Sucesso", $"Removido {quantidadeRemover} do insumo '{nomeInsumo}'.", "OK");

        EntryNome.Text = "";
        EntryQuantidade.Text = "";

        await Shell.Current.GoToAsync("//ListagemInsumos");
    }
}
