package view;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;

public class MenuView extends JFrame {
    public MenuView(ActionListener startGameListener) {
        setTitle("Game Menu");
        setSize(1000, 549);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        setLayout(new BorderLayout());

        BackgroundPanel backgroundPanel = new BackgroundPanel("/img/Menu.jpg");
        backgroundPanel.setLayout(new GridBagLayout());

        JButton startButton = new JButton("Start Game");
        startButton.setFont(new Font("Calibri", Font.BOLD, 24));
        startButton.addActionListener(startGameListener);

        backgroundPanel.add(startButton);

        add(backgroundPanel, BorderLayout.CENTER);
    }
}