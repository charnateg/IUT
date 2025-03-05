package model.observers;

import java.io.IOException;

public interface Observer {
    public void update() throws IOException;
}
