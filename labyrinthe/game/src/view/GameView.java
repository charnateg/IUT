package view;

import helpers.JPanelWithBackground;
import helpers.RoundedButton;
import helpers.RoundedLabel;
import model.Game;
import model.observers.GameObserver;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;

public class GameView extends JFrame implements GameObserver {
    private RoundedLabel _turn;
    private Game _game;
    private JPanel _moveButtonsPanel;
    public GameView(Game game,BoardView boardView, AdditionalTileView additionalTileView,PlayerView playerView) throws IOException {
        _game = game;
        setSize(1200,900);
        setResizable(false);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        _turn = new RoundedLabel("  Turn : " + _game.getTurn(),30);
        _turn.setFont(new Font("Calibri", Font.BOLD, 24));
        _turn.setLocation(100,70);
        _turn.setSize(100,50);
        _turn.setBackground(Color.WHITE);
        _turn.setOpaque(true);
        add(_turn);

        JButton _nextTurn = new RoundedButton("Next Turn",30);
        _nextTurn.setFont(new Font("Calibri", Font.BOLD, 24));
        _nextTurn.setLocation(400,70);
        _nextTurn.setSize(150,50);
        _nextTurn.setBackground(Color.WHITE);
        _nextTurn.addActionListener(e -> {
            try {
                if(!_game.nextTurn()) return;
            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }
            _turn.setText("  Turn : " + _game.getTurn());
            update();
        });
        add(_nextTurn);

        JPanel _boardPanel = boardView.getBoardPanel();
        add(_boardPanel);

        JPanel _additionalTilePanel = additionalTileView.getAdditionalTilePanel();
        add(_additionalTilePanel);


        JPanel _playerPanel = playerView.getPanel();
        add(_playerPanel);

        _moveButtonsPanel = playerView.getMoveButtons();
        add(_moveButtonsPanel);

        getContentPane().add(new JPanelWithBackground());
        setVisible(true);
    }

    @Override
    public void update() {
        repaint();
        revalidate();
        if(_game.isOver()) {
            showEndGamePanel();
        }
    }

    private void showEndGamePanel() {
        EndGameView endGameView = new EndGameView(_game.getWinner());
        endGameView.setVisible(true);
        this.dispose();
    }
}
