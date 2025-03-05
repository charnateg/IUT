package controller;

import model.*;
import model.factories.BoardFactory;
import model.factories.TaskFactory;
import view.*;

import javax.sound.sampled.*;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import controller.*;

public class GameController {
    private Game game;
    private Board board;
    private ArrayList<PlayerController> _playerControllers;
    private ArrayList<Player> _players = new ArrayList<>();
    private GameView gameView;

    public GameController() {
        _playerControllers = new ArrayList<>();
    }

    public void initializeGame() throws IOException {
        // Create board
        BoardFactory boardFactory = new BoardFactory();
        this.board = boardFactory.createBoard();

        Position positions[] = {new Position(0,0), new Position(0,6),new Position(6,6),new Position(6,0)};

        TaskFactory taskFactory = new TaskFactory();
        ArrayList<Task> tasks = taskFactory.createTasks();


        for(int i = 0; i < 4; i++)
        {
            ArrayList<Task> playerTasks = new ArrayList<>();
            for(int j = i * 6; j < i * 6 + 6; j++)
            {
                playerTasks.add(tasks.get(j));
            }
            Player p = new Player(i,playerTasks);
            p.setPosition(positions[i]);
            _players.add(p);
        }
        this.game = new Game();

        // Create player controllers
        for (Player player : _players) {
            PlayerController playerController = new PlayerController(game,board, player);
            _playerControllers.add(playerController);
        }

        // Create game
        game.addPlayers(_players);

        board.setGame(game);

        // Initialize views
        this.initializeViews();
        this.addObservers(_players);
    }

    private void initializeViews() throws IOException {
        // Create views
        PlayerView playerView = new PlayerView(game, _playerControllers);
        BoardController boardController = new BoardController(board,_players);
        BoardView boardView = new BoardView(boardController);
        AdditionalTileView additionalTileView = new AdditionalTileView(board);
        this.gameView = new GameView(game, boardView, additionalTileView, playerView);

        // Add observers
        board.addObserver(boardView);
        board.addObserver(gameView);
        board.addObserver(additionalTileView);

        game.addObserver(playerView);
    }

    private void addObservers(ArrayList<Player> players) {
        for (Player player : players) {
            player.addObserver(gameView);
        }
    }

    public void startMusic() {
        Thread musicThread = new Thread(() -> {
            try {
                File audioFile = new File("src/sfx/Majula.wav");
                AudioInputStream audioInputStream = AudioSystem.getAudioInputStream(audioFile);
                Clip clip = AudioSystem.getClip();
                clip.open(audioInputStream);
                clip.start();
                clip.loop(Clip.LOOP_CONTINUOUSLY);
                Thread.sleep(Long.MAX_VALUE);
            } catch (Exception e) {
                e.printStackTrace();
            }
        });
        musicThread.start();
    }
}