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
            await DisplayAlert("Erro", "Quantidade inv�lida.", "OK");
            return;
        }

        Produto p = new Produto();

        bool existe = p.ExisteInsumo(nomeInsumo);
        if (!existe)
        {
            await DisplayAlert("Erro", $"O insumo '{nomeInsumo}' n�o existe.", "OK");
            return;
        }

        int quantidadeAtual = p.BuscaQuantidade(nomeInsumo);

        if (quantidadeRemover > quantidadeAtual)
        {
            await DisplayAlert("Erro", $"Quantidade insuficiente no estoque. Atualmente h� {quantidadeAtual}.", "OK");
            return;
        }

        bool confirmar = await DisplayAlert("Confirma��o",
            $"Deseja remover {quantidadeRemover} unidade(s) do insumo '{nomeInsumo}'?",
            "Sim", "N�o");

        if (!confirmar) return;

        p.nome = nomeInsumo;
        p.quantidade = quantidadeRemover;
        p.RemoverQuantidade(); // Nova fun��o que subtrai

        await DisplayAlert("Sucesso", $"Removido {quantidadeRemover} do insumo '{nomeInsumo}'.", "OK");

        EntryNome.Text = "";
        EntryQuantidade.Text = "";

        await Shell.Current.GoToAsync("//ListagemInsumos");
    }
}
