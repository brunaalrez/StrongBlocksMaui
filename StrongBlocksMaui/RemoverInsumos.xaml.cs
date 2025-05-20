namespace StrongBlocksMaui;

public partial class RemoverInsumo : ContentPage
{
    public RemoverInsumo()
    {
        InitializeComponent();
    }

    private async void Remover_Clicked(object sender, EventArgs e)
    {
        string nomeInsumo = EntryNome.Text?.Trim();
        string quantidadeTexto = EntryQuantidade.Text?.Trim();

        if (string.IsNullOrWhiteSpace(nomeInsumo) || string.IsNullOrWhiteSpace(quantidadeTexto))
        {
            await DisplayAlert("Erro", "Preencha todos os campos.", "OK");
            return;
        }

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

        p.nome = nomeInsumo;
        p.quantidade = quantidadeRemover;
        p.RemoverQuantidade(); // Nova função que subtrai

        await DisplayAlert("Sucesso", $"Removido {quantidadeRemover} do insumo '{nomeInsumo}'.", "OK");

        EntryNome.Text = "";
        EntryQuantidade.Text = "";

        await Shell.Current.GoToAsync("//ListagemInsumos");
    }
}
