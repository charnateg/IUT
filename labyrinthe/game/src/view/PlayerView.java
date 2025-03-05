package view;

import controller.PlayerController;
import model.Direction;
import model.Game;
import model.Player;
import model.Task;
import helpers.RoundedPanel;
import model.observers.PlayerObserver;

import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.util.ArrayList;

public class PlayerView implements PlayerObserver {
    private JPanel _panel;
    private JPanel _moveButtonsPanel;
    private Game _game;
    private Player _player;
    private ArrayList<PlayerController> _playerController;

    public PlayerView(Game game, ArrayList<PlayerController> playerControllers) throws IOException {
        _game = game;
        _playerController = playerControllers;
        _panel = new RoundedPanel(20);
        _moveButtonsPanel = new JPanel();
        update();
    }

    public JPanel getPanel() {
        return _panel;
    }

    @Override
    public void update() throws IOException {
        _panel.removeAll();
        _player = _game.getCurrentPlayer();
        _panel.setSize(400, 330);
        _panel.setBackground(Color.WHITE);
        _panel.setLayout(new GridLayout(1, 2));
        _panel.setLocation(730, 160);
        _panel.setBorder(BorderFactory.createEmptyBorder(10, 30, 10, 10));

        JPanel playerInfo = new JPanel();
        playerInfo.setLayout(new GridLayout(_player.getTasks().size() + 2, 1));

        JLabel playerName = new JLabel("Player " + (_player.getId() + 1));
        playerName.setFont(new Font("Roboto", Font.BOLD, 24));
        playerInfo.add(playerName);


        JLabel playerTasks = new JLabel("Tasks");
        playerTasks.setFont(new Font("Roboto", Font.BOLD, 16));
        playerInfo.add(playerTasks);


        ArrayList<Task> tasks = _player.getTasks();
        for (Task task : tasks) {
            JLabel taskLabel = new JLabel();
            if (task.isCompleted())
                taskLabel.setText(task.getName() + " - Completed");
            else
                taskLabel.setText("*****************");
            taskLabel.setFont(new Font("Roboto", Font.BOLD, 16));
            taskLabel.setForeground(new Color(223, 119, 0));
            playerInfo.add(taskLabel);
        }
        _panel.add(playerInfo);

        try
        {
            String imagePath = "/img/treasures/big/" + _player.getCurrentTask().getImage();
            Image treasureImage = ImageIO.read(getClass().getResource(imagePath));
            treasureImage = treasureImage.getScaledInstance(100, 100, Image.SCALE_REPLICATE);
            JLabel currentTask = new JLabel(new ImageIcon(treasureImage));
            _panel.add(currentTask);
        }
        catch (NullPointerException e)
        {
            JLabel currentTask = new JLabel("No current task");
            currentTask.setFont(new Font("Roboto", Font.BOLD, 16));
            _panel.add(currentTask);
        }
        createMoveButtons();
        _panel.revalidate();
        _panel.repaint();
    }

    public JPanel getMoveButtons()
    {
        return _moveButtonsPanel;
    }

    public void createMoveButtons()
    {
        _moveButtonsPanel.removeAll();
        _moveButtonsPanel.setLayout(new GridLayout(3, 3));
        _moveButtonsPanel.setSize(150, 160);
        _moveButtonsPanel.setLocation(720, 500);
        _moveButtonsPanel.add(new JLabel(""));                // Top-left empty
        JButton upButton = createButton(Direction.UP);
        _moveButtonsPanel.add(upButton);                     // Top-center (up button)
        _moveButtonsPanel.add(new JLabel(""));                // Top-right empty
        JButton leftButton = createButton(Direction.LEFT);
        _moveButtonsPanel.add(leftButton);                   // Middle-left (left button)
        _moveButtonsPanel.add(new JLabel(""));                // Middle-center empty
        JButton rightButton = createButton(Direction.RIGHT);
        _moveButtonsPanel.add(rightButton);                  // Middle-right (right button)
        _moveButtonsPanel.add(new JLabel(""));                // Bottom-left empty
        JButton downButton = createButton(Direction.DOWN);
        _moveButtonsPanel.add(downButton);                  // Middle-right (right button)
        _moveButtonsPanel.add(new JLabel(""));
    }
    public JButton createButton(Direction direction) {
        String image = "/img/buttons/";
        switch (direction)
        {
            case UP:
                image += "move_up.png";
                break;
            case DOWN:
                image += "move_down.png";
                break;
            case LEFT:
                image += "move_left.png";
                break;
            case RIGHT:
                image += "move_right.png";
                break;
        }
        JButton button = new JButton(new ImageIcon(getClass().getResource(image)));
        button.addActionListener(e -> {
            try {
                _playerController.get(_player.getId()).movePlayer(direction);
            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }
        });

        button.setBackground(Color.WHITE);
        button.setBorderPainted(false);
        return button;
    }

}
