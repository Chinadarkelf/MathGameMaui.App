namespace MathGameMaui;

public partial class GamePage : ContentPage
{
	public string GameType { get; set; }

	int firstNumber = 0;
	int secondNumber = 0;
	int score = 0;
	int combo = 1;
	int gamesLeft = 5;

	public GamePage(string gameType)
	{
		InitializeComponent();
		GameType = gameType;
		BindingContext = this;

		CreateQuestion();
	}

	private void CreateQuestion()
	{
		var gameOperation = GameType switch
		{
			"Addition" => "+",
			"Subtraction" => "-",
			"Multiplication" => "*",
			"Division" => "/",
			_ => ""
		};

		var random = new Random();

		firstNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);
		secondNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);

		if (GameType == "Division")
		{
			while (firstNumber < secondNumber || firstNumber % secondNumber != 0)
			{
				firstNumber = random.Next(1, 99);
				secondNumber = random.Next(1, 99);
			}
		}

		QuestionLabel.Text = $"{firstNumber} {gameOperation} {secondNumber}";
	}

	private void OnAnswerSubmitted(object sender, EventArgs e)
	{
		var answer = Int32.Parse(Answer.Text);
		var isCorrect = false;

		switch (GameType)
		{
			case "Addition":
				isCorrect = (answer == firstNumber + secondNumber);
				break;
			case "Subtraction":
				isCorrect = (answer == firstNumber - secondNumber);
				break;
			case "Multiplication":
				isCorrect = (answer == firstNumber * secondNumber);
				break;
			case "Division":
				isCorrect = (answer == secondNumber / secondNumber);
				break;
		}

		ProcessAnswer(isCorrect);

		Answer.Text = "";
		gamesLeft--;

		if (gamesLeft > 0)
		{
			CreateQuestion();
		} else
		{
			GameOver();
		}
	}

	private void ProcessAnswer(Boolean isCorrect)
	{
		if (isCorrect)
		{
			score += combo;
			combo++;

			AnswerLabel.Text = isCorrect ? "Correct!" : "Wrong...";
		}
	}

	private void GameOver()
	{
		QuestionArea.IsVisible = false;
		BackToMenuBtn.IsVisible = true;
		GameOverLabel.Text = $"Game over! You scored {score} out of 15 points";
	}

	private void OnBackToMenu(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainPage());
	}
}