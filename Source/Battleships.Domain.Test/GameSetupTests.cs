using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Battleships.Domain.Test
{
    [TestFixture]
    public class GameSetupTests
    {
        private const int DefaultGridSize = 10;

        [Test]
        public void When_a_game_is_first_created_a_move_in_the_player_grid_returns_an_event_with_no_grid_updates()
        {
            var game = new BattleshipsGame(DefaultGridSize);

            var resultUnderTest = game.GetMoveResults(true, 0, 0);

            Assert.That(resultUnderTest.GridUpdates.Count, Is.EqualTo(0));
        }

        [Test]
        public void When_a_game_is_first_created_a_move_in_the_player_grid_returns_an_event_with_a_prompt_to_move_again_in_an_adjacent_square()
        {
            var game = new BattleshipsGame(DefaultGridSize);

            var resultUnderTest = game.GetMoveResults(true, 0, 0);

            Assert.That(resultUnderTest.Summary, Is.EqualTo("Place the other end of the patrol boat (length 2)"));
        }

        [Test]
        public void When_a_game_is_first_created_a_move_in_the_computer_grid_returns_no_summary_message()
        {
            var game = new BattleshipsGame(DefaultGridSize);

            var resultUnderTest = game.GetMoveResults(false, 0, 0);

            Assert.That(resultUnderTest.Summary, Is.EqualTo(String.Empty));
        }

        [Test]
        public void When_a_game_is_first_created_a_move_in_the_computer_grid_returns_no_grid_update_events()
        {
            var game = new BattleshipsGame(DefaultGridSize);

            var resultUnderTest = game.GetMoveResults(false, 0, 0);

            Assert.That(resultUnderTest.GridUpdates, Is.EqualTo(0));
        }

        [Test]
        public void When_a_game_is_first_created_two_moves_in_adjacent_spaces_on_the_player_grid_results_in_two_grid_updates()
        {
            var game = new BattleshipsGame(DefaultGridSize);

            game.GetMoveResults(true, 0, 0);
            var resultUnderTest = game.GetMoveResults(true, 0, 1);
            
            Assert.That(resultUnderTest.GridUpdates.Count, Is.EqualTo(2));
        }

        [Test]
        public void When_a_game_is_first_created_two_moves_in_adjacent_spaces_on_the_player_grid_returns_grid_updates_of_the_type_patrol_ship()
        {
            var game = new BattleshipsGame(DefaultGridSize);

            game.GetMoveResults(true, 0, 0);
            var resultUnderTest = game.GetMoveResults(true, 0, 1);

            Assert.That(resultUnderTest.GridUpdates
                .Count(gu => gu.PanelType != PanelType.PatrolBoat),
                Is.EqualTo(0));
        }

        [Test]
        public void When_a_game_is_first_created_two_moves_in_adjacent_spaces_on_the_player_grid_returns_grid_updates_in_the_spaces_selected()
        {
            const int columnIndexOfMoves = 0;
            const int rowIndexOfFirstMove = 0;
            const int rowIndexOfSecondMove = 1;

            var game = new BattleshipsGame(DefaultGridSize);

            game.GetMoveResults(true, rowIndexOfFirstMove, columnIndexOfMoves);
            
            var resultUnderTest = game.GetMoveResults(true, rowIndexOfSecondMove, columnIndexOfMoves);

            var firstGridUpdate = resultUnderTest.GridUpdates[0];
            var secondGridUpdate = resultUnderTest.GridUpdates[1];

            Assert.That(firstGridUpdate.ColumnIndexToUpdate, Is.EqualTo(columnIndexOfMoves));
            Assert.That(firstGridUpdate.ColumnIndexToUpdate, Is.EqualTo(columnIndexOfMoves));

            Assert.That(secondGridUpdate.ColumnIndexToUpdate, Is.EqualTo(rowIndexOfFirstMove));
            Assert.That(secondGridUpdate.ColumnIndexToUpdate, Is.EqualTo(rowIndexOfSecondMove));
        }

        [Test]
        public void When_a_game_is_first_created_two_moves_in_spaces_four_apart_returns_no_move_results()
        {
            const int columnIndexOfMoves = 0;
            const int rowIndexOfFirstMove = 0;
            const int rowIndexOfSecondMove = 4;

            var game = new BattleshipsGame(DefaultGridSize);

            game.GetMoveResults(true, rowIndexOfFirstMove, columnIndexOfMoves);
            var resultUnderTest = game.GetMoveResults(true, rowIndexOfSecondMove, columnIndexOfMoves);

            Assert.That(resultUnderTest.GridUpdates.Count, Is.EqualTo(0));
        }

        [Test]
        public void When_a_game_is_first_created_two_moves_in_spaces_four_apart_returns_a_relevant_summary_message()
        {
            const int columnIndexOfMoves = 0;
            const int rowIndexOfFirstMove = 0;
            const int rowIndexOfSecondMove = 4;

            var game = new BattleshipsGame(DefaultGridSize);

            game.GetMoveResults(true, rowIndexOfFirstMove, columnIndexOfMoves);
            var resultUnderTest = game.GetMoveResults(true, rowIndexOfSecondMove, columnIndexOfMoves);

            Assert.That(resultUnderTest.Summary, Is.EqualTo("Click the start and end of the patrol boat, 2 spaces apart."));
        }
    }
}
