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

            Assert.That(resultUnderTest.Summary, Is.EqualTo("Place the other end of the PatrolBoat"));
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

            Assert.That(resultUnderTest.GridUpdates.Count, Is.EqualTo(0));
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

            game.GetMoveResults(true, columnIndexOfMoves, rowIndexOfFirstMove);

            var resultUnderTest = game.GetMoveResults(true, columnIndexOfMoves, rowIndexOfSecondMove);

            var firstGridUpdate = resultUnderTest.GridUpdates[0];
            var secondGridUpdate = resultUnderTest.GridUpdates[1];

            Assert.That(firstGridUpdate.ColumnIndexToUpdate, Is.EqualTo(columnIndexOfMoves));
            Assert.That(firstGridUpdate.RowIndexToUpdate, Is.EqualTo(rowIndexOfFirstMove));

            Assert.That(secondGridUpdate.ColumnIndexToUpdate, Is.EqualTo(columnIndexOfMoves));
            Assert.That(secondGridUpdate.RowIndexToUpdate, Is.EqualTo(rowIndexOfSecondMove));
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

            game.GetMoveResults(true, columnIndexOfMoves, rowIndexOfFirstMove);
            var resultUnderTest = game.GetMoveResults(true, columnIndexOfMoves, rowIndexOfSecondMove);

            Assert.That(resultUnderTest.Summary, Is.EqualTo("Place the other end of the PatrolBoat"));
        }

        [Test]
        public void After_placing_the_patrol_boat_the_next_move_will_prompt_to_place_the_cruiser()
        {
            const int columnIndexOfMoves = 0;
            const int rowIndexOfFirstMove = 0;
            const int rowIndexOfSecondMove = 1;
            const int rowIndexOfThirdMove = 6;

            var game = new BattleshipsGame(DefaultGridSize);

            game.GetMoveResults(true, rowIndexOfFirstMove, columnIndexOfMoves);
            game.GetMoveResults(true, rowIndexOfSecondMove, columnIndexOfMoves);

            var resultUnderTest = game.GetMoveResults(true, columnIndexOfMoves, rowIndexOfThirdMove);
            
            Assert.That(resultUnderTest.Summary, Is.EqualTo("Place the other end of the Cruiser"));
        }

        [Test]
        public void After_placing_the_patrol_boat_and_the_first_space_of_the_cruiser_the_next_move_two_spaces_placed_away_will_be_three_grid_updates()
        {
            const int columnIndexOfMoves = 0;
            const int rowIndexOfFirstMove = 0;
            const int rowIndexOfSecondMove = 1;
            const int rowIndexOfThirdMove = 6;
            const int rowIndexOfFourthMove = 8;

            var game = new BattleshipsGame(DefaultGridSize);

            game.GetMoveResults(true, rowIndexOfFirstMove, columnIndexOfMoves);
            game.GetMoveResults(true, rowIndexOfSecondMove, columnIndexOfMoves);
            game.GetMoveResults(true, columnIndexOfMoves, rowIndexOfThirdMove);
            
            var resultUnderTest = game.GetMoveResults(true, columnIndexOfMoves, rowIndexOfFourthMove);

            Assert.That(resultUnderTest.GridUpdates.Count, Is.EqualTo(3));
        }
    }
}
