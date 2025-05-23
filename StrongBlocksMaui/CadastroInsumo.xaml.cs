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

        int id_produto = 1;
        if (nomeInsumo.ToLower() == "areia")
            id_produto = 1;
        if (nomeInsumo.ToLower() == "cimento")
            id_produto = 2;
        if (nomeInsumo.ToLower() == "po de pedra")
            id_produto = 3;

        p.id = id_produto;
        p.nome = nomeInsumo;
        p.quantidade = quantidade;
        p.tipo = "Insumo";
        p.Atualiza();

        // Limpa os campos após salvar
        EntryNome.Text = string.Empty;
        EntryQuantidade.Text = string.Empty;

        await Shell.Current.GoToAsync("//ListagemInsumos");
    }
}
