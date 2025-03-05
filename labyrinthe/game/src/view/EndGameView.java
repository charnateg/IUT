package view;

import controller.GameController;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;

public class EndGameView extends JFrame {
    public EndGameView(String winner) {
        setTitle("Game Over");
        setSize(1000, 563);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        setLayout(new BorderLayout());

        BackgroundPanel backgroundPanel = new BackgroundPanel("/img/End.jpg");
        backgroundPanel.setLayout(new BorderLayout());

        JLabel winnerLabel = new JLabel("Winner: " + winner, SwingConstants.CENTER);
        winnerLabel.setFont(new Font("Calibri", Font.BOLD, 24));
        backgroundPanel.add(winnerLabel, BorderLayout.CENTER);

        JButton restartButton = new JButton("Restart Game");
        restartButton.setFont(new Font("Calibri", Font.BOLD, 24));
        restartButton.addActionListener(e -> {
            dispose();
            SwingUtilities.invokeLater(() -> {
                try {
                    GameController gameController = new GameController();
                    gameController.startMusic();
                    gameController.initializeGame();
                } catch (IOException ex) {
                    ex.printStackTrace();
                }
            });
        });
        backgroundPanel.add(restartButton, BorderLayout.SOUTH);

        add(backgroundPanel);
    }
}