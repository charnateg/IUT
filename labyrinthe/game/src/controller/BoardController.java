package controller;

import model.Board;
import model.Player;
import model.Position;

import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

public class BoardController {
    private Board _board;
    private ArrayList<Player> _players;

    public BoardController(Board board, ArrayList<Player> players) {
        this._board = board;
        this._players = players;
    }

    /**
     * Shift a row or column and update player positions if successful.
     *
     * @param rowToShift   Row index to shift, -1 if shifting column
     * @param colToShift   Column index to shift, -1 if shifting row
     * @param direction    Direction of the shift (1 or -1)
     * @return True if the shift was successful, false otherwise
     * @throws IOException If tile movement causes an error
     */
    public boolean shiftAndUpdate(int rowToShift, int colToShift, int direction) throws IOException {
        boolean shiftSuccessful = false;

        if (rowToShift >= 0 && colToShift == -1) {
            shiftSuccessful = _board.shiftRow(_board.getMovableTile(), rowToShift, direction);
            if (shiftSuccessful) {
                updatePlayerPositions(rowToShift, colToShift, direction, true);
            }
        } else if (rowToShift == -1 && colToShift >= 0) {
            shiftSuccessful = _board.shiftCol(_board.getMovableTile(), colToShift, direction);
            if (shiftSuccessful) {
                updatePlayerPositions(rowToShift, colToShift, direction, false);
            }
        }

        if (shiftSuccessful) {
            playSlideSound();
        }

        return shiftSuccessful;
    }

    /**
     * Update player positions after a row or column shift.
     *
     * @param rowToShift   Row index shifted
     * @param colToShift   Column index shifted
     * @param direction    Direction of the shift
     * @param isRowShift   True if a row was shifted, false if column
     */
    private void updatePlayerPositions(int rowToShift, int colToShift, int direction, boolean isRowShift) throws IOException {
        for (Player player : _players) {
            Position pos = player.getPosition();
            if (isRowShift && pos.row == rowToShift) {
                player.setPosition(new Position(pos.row, pos.col + direction));
            } else if (!isRowShift && pos.col == colToShift) {
                player.setPosition(new Position(pos.row - direction, pos.col));
            }
        }
    }

    /**
     * Play the sliding sound effect.
     */
    private void playSlideSound() {
        try {
            File audioFile = new File("src/sfx/slide.wav");
            AudioInputStream audioInputStream = AudioSystem.getAudioInputStream(audioFile);
            Clip clip = AudioSystem.getClip();
            clip.open(audioInputStream);
            clip.start();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public Board getBoard() {
        return _board;
    }

    public ArrayList<Player> getPlayers() {
        return _players;
    }
}
