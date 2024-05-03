using ChessLogic;
using System.Windows;
using System.Windows.Controls;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {
        public event Action<Option> OptionSelected;

        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();

            Result result = gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);
        }

        private static string GetWinnerText(Player winner)
        {
            return winner switch
            {
                Player.White => "White won!",
                Player.Black => "Black won!",
                _ => "Draw",
            };
        }

        private static string PlayerString(Player player)
        {
            return player switch
            {
                Player.White => "White",
                Player.Black => "Black",
                _ => ""
            };
        }

        private static string GetReasonText(EndReason reason, Player currentPlayer)
        {
            return reason switch
            {
                EndReason.Stalemate => "Stalemate!",
                EndReason.Checkmate => $"{PlayerString(currentPlayer.Opponent())} won by checkmate!",
                _ => ""
            };
        }

        private void Restart_Click( object sender, RoutedEventArgs e )
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_click( object sender, RoutedEventArgs e )
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}
