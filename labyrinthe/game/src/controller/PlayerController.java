package controller;

import model.*;
import model.tiles.Tile;

import java.io.IOException;

public class PlayerController {
    private Player _player;
    private Board _board;
    private Game _game;
    public PlayerController(Game game,Board board,Player player) {
        _player = player;
        _board = board;
        _game = game;
    }

    public boolean movePlayer(Direction direction) throws IOException {
        if(!_player.canMove()) return false;
        Position currentPosition = _player.getPosition();
        Position newPosition = new Position(-1,-1);
        // We use t1 and t2 to determine later if the tile (t2 : the next tile) can be entered from the current tile (t1 the current one)
        // t1 and t2 correspond to the indexes of the directions array of the tile
        // 0 = up, 1 = right, 2 = down, 3 = left
        int t1 = -1;
        int t2 = -1;

        switch (direction) {
            case UP:
                newPosition = new Position(currentPosition.row -1, currentPosition.col );
                t1 = 0;
                t2 = 2;
                break;
            case DOWN:
                newPosition = new Position(currentPosition.row +1, currentPosition.col);
                t1 = 2;
                t2 = 0;
                break;
            case LEFT:
                newPosition = new Position(currentPosition.row, currentPosition.col -1);
                t1 = 3;
                t2 = 1;
                break;
            case RIGHT:
                newPosition = new Position(currentPosition.row , currentPosition.col + 1);
                t1 = 1;
                t2 = 3;
                break;
        }
        // Check if the row and col are within the board
        if(newPosition.row < 0 || newPosition.row > 6) return false;
        if(newPosition.col < 0 || newPosition.col > 6) return false;

        // Check if the tile can be entered from the current tile
        Tile currentTile = _board.getTile(currentPosition.row, currentPosition.col);
        Tile newTile = _board.getTile(newPosition.row, newPosition.col);
        if(currentTile.getDirections()[t1] && newTile.getDirections()[t2])
        {
            _player.setPosition(newPosition);
            if (_player.getCurrentTask() != null && newTile.getTask() != null
                    && _player.getCurrentTask().getId() == newTile.getTask().getId()) {
                _player.finishTask(newTile.getTask());
                _board.removeTreasure(newTile.getTask().getId());
                _game.nextTurn();
            }

        }
        // update the map if the player has moved
        _board.notifyObservers();
        return true;
    }

}
