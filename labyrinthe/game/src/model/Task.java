package model;

public class Task {
    private boolean _completed;
    private Treasure _treasure;
    private int _id;

    public Task(int id, Treasure treasure) {
        _treasure = treasure;
        _id = id;
        _completed = false;
    }
    /**
     * Check if the task is completed
     * @return true if the task is completed, false otherwise
     */
    public boolean isCompleted() {
        return _completed;
    }
    /**
     * Mark the task as completed
     * @return void
     */
    public void complete() {
        _completed = true;
    }

    public String getName() {
        return _treasure.toString();
    }
    public int getId() {
        return _id;
    }
    public Treasure getTreasure() {
        return _treasure;
    }
    public String getImage()
    {
        return _id + ".png";
    }


    public String toString() {
        return "Task - " + (_completed ? "Completed" : "Not completed");
    }

}
