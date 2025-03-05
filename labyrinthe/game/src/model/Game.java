package model;

import model.observers.Observer;
import model.observers.PlayerObserver;

import java.io.IOException;
import java.util.ArrayList;

public class Game implements Observable {
    private ArrayList<Player> _players;
    private int _turn;
    private Player _currentPlayer;
    private Board _board;
    private int _winner;
    private PlayerObserver _playerObserver;

    public Game()
    {
    }
    public void addPlayers(ArrayList<Player> players)
    {
        _players = players;
        _currentPlayer = _players.get(0);
    }
    public void addBoard(Board board)
    {
        _board = board;
    }

    @Override
    public void addObserver(Observer observer) {
        if(observer instanceof PlayerObserver)
        {
            _playerObserver = (PlayerObserver) observer;
        }

    }

    @Override
    public void notifyObservers() {
        try {
            _playerObserver.update();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public boolean nextTurn() throws IOException {
        if(!_currentPlayer.isShifted()) return false;
        _currentPlayer.setShifted(false);
        _turn ++;
        _currentPlayer = _players.get(_turn % _players.size());
        _playerObserver.update();
        return true;
    }

    public boolean isOver()
    {
        for(Player player : _players)
        {
            if(player.hasFinishedAllTasks() && player.inInitialPosition())
            {
                _winner = player.getId();
                return true;
            }
        }
        return false;
    }

    public int getTurn()
    {
        return _turn;
    }

    public String getWinner()
    {
        if (_winner == -1) return null;
        for(Player player : _players)
        {
            if (player.getId() == _winner) return "Player + " + player.getId();
        }
        return null;
    }
    public ArrayList<Player> getPlayers()
    {
        return _players;
    }

    public Player getCurrentPlayer() {
        return _currentPlayer;
    }
}
