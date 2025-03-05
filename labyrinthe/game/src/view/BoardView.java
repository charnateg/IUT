package view;

import controller.BoardController;
import helpers.ImageHelper;
import model.Board;
import model.Player;
import model.Position;
import model.tiles.Tile;
import model.observers.BoardObserver;

import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.IOException;

public class BoardView implements BoardObserver {
    private BoardController _boardController;
    private JPanel _boardPanel;

    public BoardView(BoardController boardController) throws IOException {
        _boardController = boardController;
        _boardPanel = new JPanel();
        update();
    }

    public JPanel getBoardPanel() {
        return _boardPanel;
    }

    @Override
    public void update() throws IOException {
        _boardPanel.removeAll();
        _boardPanel.setOpaque(true);
        _boardPanel.setBackground(new Color(0, 0, 0, 20));
        _boardPanel.setSize(614, 620);
        _boardPanel.setLocation(72, 148);
        _boardPanel.setLayout(new GridLayout(9, 9));

        createShiftDownButtons();
        for (int i = 1; i < 8; i++) {
            createShiftRightButtons(i);
            createBoard(i);
            createShiftLeftButtons(i);
        }
        createShiftUpButtons();

        _boardPanel.revalidate();
        _boardPanel.repaint();
    }

    private void createBoard(int row) throws IOException {
        for (int col = 0; col < 7; col++) {
            Tile tile = _boardController.getBoard().getTile(row - 1, col);
            BufferedImage image = (BufferedImage) tile.getImage();

            // Overlay tasks and players
            if (tile.getTask() != null) {
                image = ImageHelper.merge(image, "/img/treasures/" + tile.getTask().getId() + ".png");
            }
            for (Player player : _boardController.getPlayers()) {
                if (player.getPosition().row == row - 1 && player.getPosition().col == col) {
                    image = ImageHelper.merge(image, "/img/players/" + player.getId() + ".png");
                }
            }

            _boardPanel.add(new JLabel(new ImageIcon(image)));
        }
    }

    private JButton createShiftButton(String img, int rowToShift, int colToShift, int direction) throws IOException {
        JButton button = new JButton(new ImageIcon(ImageIO.read(getClass().getResource("/img/buttons/" + img))));
        button.addActionListener(e -> {
            try {
                if (_boardController.shiftAndUpdate(rowToShift, colToShift, direction)) {
                    update();
                }
            } catch (IOException ex) {
                ex.printStackTrace();
            }
        });
        button.setBackground(Color.BLACK);
        button.setBorderPainted(false);
        return button;
    }

    private void createShiftDownButtons() throws IOException {
        for (int i = 0; i < 9; i++) {
            _boardPanel.add((i % 2 == 0 && i != 0 && i != 8) ? createShiftButton("arr_down.png", -1, i - 1, -1) : new JLabel());
        }
    }

    private void createShiftRightButtons(int row) throws IOException {
        _boardPanel.add((row % 2 == 0) ? createShiftButton("arr_right.png", row - 1, -1, 1) : new JLabel());
    }

    private void createShiftLeftButtons(int row) throws IOException {
        _boardPanel.add((row % 2 == 0) ? createShiftButton("arr_left.png", row - 1, -1, -1) : new JLabel());
    }

    private void createShiftUpButtons() throws IOException {
        for (int i = 0; i < 9; i++) {
            _boardPanel.add((i % 2 == 0 && i != 0 && i != 8) ? createShiftButton("arr_up.png", -1, i - 1, 1) : new JLabel());
        }
    }
}
