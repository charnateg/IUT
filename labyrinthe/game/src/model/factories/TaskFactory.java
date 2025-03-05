package model.factories;

import model.Task;
import model.Treasure;

import java.util.ArrayList;
import java.util.Collections;

public class TaskFactory {

    public ArrayList<Task> createTasks()
    {
        ArrayList<Task> tasks = new ArrayList<>();

        // Generate tasks for each treasure
        int id = 0;
        for (Treasure treasure : Treasure.values()) {
            tasks.add(new Task(id++, treasure));
        }

        // Shuffle the list of tasks
        Collections.shuffle(tasks);
        return tasks;
    }
}
