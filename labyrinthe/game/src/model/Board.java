package model;

import model.tiles.Tile;
import model.tiles.TileStraight;
import model.observers.Observer;
import model.observers.BoardObserver;
import model.observers.GameObserver;
import model.observers.TileObserver;

import java.io.IOException;

public class Board implements Observable {
    private Tile[][] _board;
    private Game _game;
    private Tile _movableTile;
    private BoardObserver _boardObserver;
    private GameObserver _gameObserver;
    private TileObserver _additionalTileObserver;
    private int _height = 7;
    private int _width = 7;
    private int _lastMovedRow;
    private int _lastMovedCol;
    private  int _direction;

    public Board()
    {
        _board = new Tile[_width][_height];
        Tile tile = new TileStraight(2);
        _movableTile = tile;
    }
    public void setGame(Game game)
    {
        _game = game;
    }

    public boolean shiftRow(Tile tile, int row, int direction) throws IOException {
        if(_game.getCurrentPlayer().isShifted()) return false;
        // Determine the starting and ending indices for the row shift
        if(row == _lastMovedRow && direction != _direction)
            return false;
        int start = direction == 1 ? 0 : _width - 1;
        int end = direction == 1 ?  _width - 1 : 0;
        // Store the tile that will be returned
        Tile returnedTile = direction == 1 ? _board[row][_width - 1] : _board[row][0];

        Position _lastTilePosition = new Position(row, end);
        System.out.println(end);
        for(Player player : _game.getPlayers())
        {
            if(player.getPosition().equals(_lastTilePosition))
            {
                if(direction == 1)
                    player.setPosition( new Position(row,start - 1 ));
                else player.setPosition( new Position(row,start + 1 ));
            }
        }

        // Shift tiles to the right or left
        if (direction == 1) {
            // Move elements from the right to left
            for (int i = _width - 1; i > start; i--) {
                _board[row][i] = _board[row][i - 1];
            }
        } else {
            // Move elements from the left to right
            for (int i = 0; i < start; i++) {
                _board[row][i] = _board[row][i + 1];
            }
        }

        // Place the new tile at the correct position
        _board[row][start] = tile;

        // Update movement tracking
        _lastMovedRow = row;
        _lastMovedCol = -1;
        _movableTile = returnedTile;
        _direction = direction;


        _game.getCurrentPlayer().setShifted(true);
        notifyObservers();
        return true;
    }

    public boolean shiftCol(Tile tile, int col, int direction) throws IOException {
        if(_game.getCurrentPlayer().isShifted()) return false;

        // direction = 1 for up, -1 for down
        if(col == _lastMovedCol && direction != _direction)
            return false;
        // The tile that will "fall off" the column
        Tile returnedTile = direction == 1 ? _board[0][col] : _board[_height-1][col];
        // Shift tiles up or down
        int start = direction == 1 ? 0 : _height ;
        int end = direction == 1 ?  _height : 0;

        Position _lastTilePosition = new Position(start, col);

        for(Player player : _game.getPlayers())
        {
            if(player.getPosition().equals(_lastTilePosition))
            {
                player.setPosition( new Position(end,col));
            }
        }

        if(direction == 1)
        {
            for(int i = 0; i < _height - 1; i++)
            {
                _board[i][col] = _board[i + 1][col];
            }
            _board[_height - 1][col] = tile;
        }
        else
        {
            for(int i = _height - 1; i > 0; i--)
            {
                _board[i][col] = _board[i - 1][col];
            }
            _board[0][col] = tile;
        }
        // Place the new tile at the correct position

        // Update movement tracking
        _lastMovedRow = -1;  // Record where the tile was placed
        _lastMovedCol = col;
        _movableTile = returnedTile;
        _direction = direction;
        _game.getCurrentPlayer().setShifted(true);
        notifyObservers();
        return true;
    }

    public void removeTreasure(int id)
    {
        for(int i = 0; i < _height; i++)
        {
            for(int j = 0; j < _width; j++)
            {
                if(_board[i][j] != null && _board[i][j].getTask() != null && _board[i][j].getTask().getId() == id)
                {
                    _board[i][j].removeTask();
                }
            }
        }
    }

    public void setTile(int row, int col, Tile tile)
    {
        _board[row][col] = tile;
    }

    public Tile getTile(int row, int col)
    {
        return _board[row][col];
    }


    public Tile getMovableTile()
    {
        return _movableTile;
    }

    @Override
    public void addObserver(Observer observer) {
        if (observer instanceof BoardObserver) {
            _boardObserver = (BoardObserver) observer;
        } else if (observer instanceof GameObserver) {
            _gameObserver = (GameObserver) observer;
        }
        else if (observer instanceof TileObserver) {
            _additionalTileObserver = (TileObserver) observer;
        }

    }

    @Override
    public void notifyObservers() throws IOException {
        _boardObserver.update();
        _gameObserver.update();
        _additionalTileObserver.update();
    }
}
