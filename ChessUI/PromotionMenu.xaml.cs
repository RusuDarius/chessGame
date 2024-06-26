﻿using ChessLogic;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for PromotionMenu.xaml
    /// </summary>
    public partial class PromotionMenu : UserControl
    {
        // Idea is: Main window will register this event, when piece is chosen, event will be invoked with the type of that specific piece
        public event Action<PieceType> PieceSelected;

        public PromotionMenu(Player player)
        {
            InitializeComponent();

            QueenImage.Source = Images.GetImage(player, PieceType.Queen);
            BishopImage.Source = Images.GetImage(player, PieceType.Bishop);
            RookImage.Source = Images.GetImage(player, PieceType.Rook);
            KnightImage.Source = Images.GetImage(player, PieceType.Knight);
        }

        private void QueenImage_MouseDown( object sender, MouseButtonEventArgs e )
        {
            PieceSelected?.Invoke(PieceType.Queen);
        }

        private void BishopImage_MouseDown( object sender, MouseButtonEventArgs e )
        {
            PieceSelected?.Invoke(PieceType.Bishop);

        }

        private void RookImage_MouseDown( object sender, MouseButtonEventArgs e )
        {
            PieceSelected?.Invoke(PieceType.Rook);
        }

        private void KnightImage_MouseDown( object sender, MouseButtonEventArgs e )
        {
            PieceSelected?.Invoke(PieceType.Knight);
        }
    }
}
