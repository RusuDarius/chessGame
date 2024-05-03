using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {
        public event Action<Option> OptionSelected;

        public GameOverMenu()
        {
            InitializeComponent();
        }

        private static string GetWinnerText(Player winner)
        {
            return winner switch
            {
                Player.White => "White won!",
                Player.Black => "Black won!",
                _ => "Draw!",
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
