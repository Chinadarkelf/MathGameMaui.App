namespace MathGameMaui;

public partial class PreviousGames : ContentPage
{
	public string[] Games { get; set; }
	public PreviousGames()
	{
		InitializeComponent();
		App.GameRepository.GetAllGames();

		gamesList.ItemsSource = App.GameRepository.GetAllGames();
	}


}