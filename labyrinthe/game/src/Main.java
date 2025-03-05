import controller.GameController;
import view.MenuView;

import javax.swing.*;
import java.io.IOException;

public class Main {
    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            MenuView menuView = new MenuView(e -> {
                try {
                    GameController gameController = new GameController();
                    gameController.startMusic();
                    gameController.initializeGame();
                } catch (IOException ex) {
                    ex.printStackTrace();
                }
            });
            menuView.setVisible(true);
        });
    }
}