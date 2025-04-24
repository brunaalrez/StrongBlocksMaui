namespace StrongBlocksMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Produto p = new Produto();
            Lista.ItemsSource = p.BuscaTodos();
        }

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            Produto p = new Produto();
            p.tipo_insumo = EntryInsumo.Text;
            p.quantidade = int.Parse(EntryInsumo.Text);
            p.Insere();

            Lista.ItemsSource = null;
            Lista.ItemsSource = p.BuscaTodos();
        }
    }
}
