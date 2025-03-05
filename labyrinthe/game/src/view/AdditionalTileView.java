package view;

import helpers.ImageHelper;
import model.Board;
import model.observers.TileObserver;
import model.tiles.Tile;

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.IOException;

public class AdditionalTileView implements TileObserver {
    private JLabel _additionalTile;
    private JPanel _additionalTilePanel;
    private Board _board;
    private Tile _tile;

    public AdditionalTileView(Board board) throws IOException {
        _board = board;
        _additionalTilePanel = new JPanel();
        _additionalTilePanel.setLayout(new GridLayout(2, 1));
        _additionalTilePanel.setLocation(950, 500);
        _additionalTilePanel.setOpaque(false);
        _additionalTilePanel.setSize(200, 330);
        _additionalTilePanel.setBorder(new EmptyBorder(3, 0,0,0));

        Image tileImage = _board.getMovableTile().getBigImage();
        _additionalTile = new JLabel(new ImageIcon(tileImage));
        _additionalTile.setSize(100, 100);
        _additionalTilePanel.add(_additionalTile);

        JPanel buttonPanel = new JPanel();
        buttonPanel.setLayout(new GridLayout(1, 2));
        buttonPanel.setOpaque(false);


        JButton rotateCounterClockButton = createRotateButton("rotate_left.png", -1);
        buttonPanel.add(rotateCounterClockButton);

        JButton rotateClockwiseButton = createRotateButton("rotate_right.png", 1);
        buttonPanel.add(rotateClockwiseButton);
        _additionalTilePanel.add(buttonPanel);

        _tile = _board.getMovableTile();
    }

    public JButton createRotateButton(String img, int direction) throws IOException {
        String image = "/img/buttons/" + img;
        JButton button = new JButton(new ImageIcon(ImageIO.read(getClass().getResource(image))));
        button.addActionListener(e -> {
            _board.getMovableTile().rotate(direction);
            try {
                update();
            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }
        });

        button.setBackground(Color.WHITE);
        button.setBorderPainted(false);
        return button;
    }

    public void update() throws IOException {
        _tile = _board.getMovableTile();
        BufferedImage tileImage = (BufferedImage) _tile.getBigImage();
        if(_tile.getTask() != null)
        {
            tileImage = ImageHelper.merge(tileImage, "/img/treasures/" + _tile.getTask().getId() + ".png");
        }
        _additionalTile.setIcon(new ImageIcon(tileImage));
        _additionalTile.repaint();
        _additionalTile.revalidate();
    }

    public JPanel getAdditionalTilePanel() {
        return _additionalTilePanel;
    }
}
