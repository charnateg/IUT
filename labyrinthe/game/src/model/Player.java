package model;

import model.observers.BoardObserver;
import model.observers.GameObserver;
import model.observers.Observer;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Player implements Observable {
    private int _id;
    private ArrayList<Task> _tasks;
    private boolean _shifted;
    private Position _position;
    private BoardObserver _boardObserver;
    private GameObserver _gameObserver;

    public Player(int id, ArrayList<Task> tasks) {
        _id = id;
        _tasks = tasks;
        _shifted = false;
    }

    public void setPosition(Position position) throws IOException {
        _position = position;
        notifyObservers();
    }
    public boolean canMove()
    {
        return _shifted;
    }
    public void setShifted(boolean value)
    {
        _shifted = value;
    }
    public boolean isShifted()
    {
        return _shifted;
    }

    public Position getPosition() {
        return _position;
    }

    /**
     * Finish a task and add the treasure to the player's treasures
     * @param task the task to finish
     * @return void
     */
    public void finishTask(Task task) {
        for (Task t : _tasks)
        {
            if (t.getId() == task.getId())
                t.complete();
        }
    }
    public boolean hasFinishedAllTasks() {
        for (Task task : _tasks)
        {
            if (!task.isCompleted())
                return false;
        }
        return true;
    }

    public boolean inInitialPosition() {
        switch (_id)
        {
            case 0:
                return _position.row == 0 && _position.col == 0;
            case 1:
                return _position.row == 0 && _position.col == 6;
            case 2:
                return _position.row == 6 && _position.col == 0;
            case 3:
                return _position.row == 6 && _position.col == 6;
        }
        return false;
    }

    public Task getCurrentTask() {
        for (Task task : _tasks)
        {
            if (!task.isCompleted())
                return task;
        }
        return null;
    }

    public int getId() {
        return _id;
    }


    public ArrayList<Task> getTasks() {
        return _tasks;
    }

    @Override
    public void addObserver(Observer observer) {
        if (observer instanceof BoardObserver)
            _boardObserver = (BoardObserver) observer;
        else if (observer instanceof GameObserver)
            _gameObserver = (GameObserver) observer;
    }

    @Override
    public void notifyObservers() throws IOException {
        if(_boardObserver != null)
            _boardObserver.update();
        if(_gameObserver != null)
            _gameObserver.update();
    }
}
