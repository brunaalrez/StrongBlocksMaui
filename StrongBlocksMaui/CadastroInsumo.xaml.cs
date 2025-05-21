namespace StrongBlocksMaui;

public partial class CadastroInsumo : ContentPage
{
    public CadastroInsumo()
    {
        InitializeComponent();
    }

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
        // Garantindo que nomeInsumo e quantidadeTexto nunca sejam null, apenas strings vazias se for o caso
        string nomeInsumo = EntryNome.Text?.Trim() ?? "";
        string quantidadeTexto = EntryQuantidade.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(nomeInsumo) || string.IsNullOrWhiteSpace(quantidadeTexto))
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

        bool existe = p.ExisteInsumo(nomeInsumo);
        if (!existe)
        {
            await DisplayAlert("Insumo não encontrado", $"O insumo '{nomeInsumo}' não existe no banco de dados.", "OK");
            return;
        }

        p.nome = nomeInsumo;
        p.quantidade = quantidade;
        p.tipo = "insumo";
        p.Atualiza();

        // Limpa os campos após salvar
        EntryNome.Text = string.Empty;
        EntryQuantidade.Text = string.Empty;

        await Shell.Current.GoToAsync("//ListagemInsumos");
    }
}
