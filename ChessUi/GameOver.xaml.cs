using ChessLogic;
using System.Windows;
using System.Windows.Controls;

namespace ChessUi
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : UserControl
    {
        public event Action<Options> OptionSelected;

        public GameOver(GameState gameState)
        {

            InitializeComponent();

            Result result= gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text= GetReasonText(result.Reason, gameState.CurrentPlayer);

        }

        private static string GetWinnerText(Player player)
        {
            return player switch
            {
                Player.Black => "BLACK WINS",
                Player.White => "WHITE WINS",
                _ => "IT'S A DRAW"
            };
        }

        private static string PlayerString(Player player)
        {
            return player switch
            {
                Player.Black => "Black",
                Player.White => "White",
                _ => ""
            };
        }

        private static string GetReasonText(EndReason Reason, Player CurrentPlayer)
        {
            return Reason switch
            {
                EndReason.Stalemate => $"STALEMATE - {PlayerString(CurrentPlayer)} cannot move",
                EndReason.Checkmate => $"CHECHMATE - {PlayerString(CurrentPlayer)} is defeated",
                EndReason.FiftyMoveRule => "FIFTY-MOVE RULE - DRAW",
                EndReason.InsufficientMaterial => "INSUFFICIENT MATERIAL - DRAW",
                EndReason.ThreefoldRepetition => "THREEFOLD REPETITION - DRAW",
                _ => "",
            };
            
        }

        private void RestartClick(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Options.Restart);
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Options.Exit);
        }
    }
}
