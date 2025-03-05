package model;

import model.observers.Observer;

import java.io.IOException;

public interface Observable {
    void addObserver(Observer observer);
    void notifyObservers() throws IOException;
}
