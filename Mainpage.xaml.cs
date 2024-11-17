using Microsoft.Maui.Controls;

namespace CadastroEventoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCadastrarEventoClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomeEntry.Text) ||
                string.IsNullOrWhiteSpace(ParticipantesEntry.Text) ||
                string.IsNullOrWhiteSpace(CustoEntry.Text))
            {
                DisplayAlert("Erro", "Preencha todos os campos obrigatórios", "OK");
                return;
            }

            try
            {
                string nomeEvento = NomeEntry.Text;
                DateTime dataInicio = DataInicioPicker.Date;
                DateTime dataTermino = DataTerminoPicker.Date;
                int numeroParticipantes = int.Parse(ParticipantesEntry.Text);
                decimal custoPorParticipante = decimal.Parse(CustoEntry.Text);

                if (dataInicio > dataTermino)
                {
                    DisplayAlert("Erro", "A data de início não pode ser posterior à data de término", "OK");
                    return;
                }

                TimeSpan duracao = dataTermino - dataInicio;
                decimal custoTotal = numeroParticipantes * custoPorParticipante;

                string mensagem = $"Evento: {nomeEvento}\n" +
                                  $"Data de Início: {dataInicio:dd/MM/yyyy}\n" +
                                  $"Data de Término: {dataTermino:dd/MM/yyyy}\n" +
                                  $"Duração: {duracao.Days + 1} dias\n" +
                                  $"Número de Participantes: {numeroParticipantes}\n" +
                                  $"Custo Total: {custoTotal:C}";

                DisplayAlert("Resumo do Evento", mensagem, "OK");
            }
            catch (FormatException)
            {
                DisplayAlert("Erro", "Certifique-se de que os números estão no formato correto", "OK");
            }
        }
    }
}
