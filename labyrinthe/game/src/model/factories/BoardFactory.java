package model.factories;

import model.tiles.*;
import model.Task;
import model.Board;
import model.Treasure;
import java.util.ArrayList;
import java.util.Random;

public class BoardFactory {
    private Board _board;
    private ArrayList<Tile> _tiles;
    private Treasure[] _treasures;
    private ArrayList<Task> _tasks;

    public BoardFactory() {
        _board = new Board();
        _tiles = new ArrayList<>();
        _treasures = Treasure.values();
        _tasks = new ArrayList<>();
    }

    public Board createBoard() {
        // Create the tiles
        createTiles();

        // Create the tasks
        int id = 0;
        for (Treasure treasure : _treasures) {
            System.out.println(id);
            _tasks.add(new Task(id,treasure));
            id++;
        }
        // put the tiles on the _board

        Random rnd = new Random();
        for(Task task : _tasks) {
            boolean found = false;
            while(!found)
            {
                int randomIndex = rnd.nextInt(4,_tiles.size() -1);
                if(_tiles.get(randomIndex).getTask() == null) {
                    _tiles.get(randomIndex).setTask(task);
                    found = true;
                }
            }
        }
        composeBoard();
        return _board;
    }

    public ArrayList<Tile> createTiles() {
        // Create the tiles
        // 20 TileCurve
        for (int i = 0; i < 20; i++) {
            _tiles.add(new TileCurve(i));
        }
        // 12 TileStraight
        for (int i = 20; i < 32; i++) {
            _tiles.add(new TileStraight(i));
        }
        // 18 TileT
        for (int i = 32; i < 50; i++) {
            _tiles.add(new TileT(i));
        }
        return _tiles;
    }

    public Board composeBoard() {
        // put the tiles on the _board
        int[][] corners = {{0, 0}, {0, 6}, {6, 6}, {6, 0}};
        int[][] tFixed = {{0,2, 0}, {0,4, 0},
                    {2,0, 3}, {2,2, 3}, {2,4, 0}, {2,6, 1},
                    {4,0, 3}, {4,2, 2}, {4,4, 1}, {4,6, 1},
                            {6,2, 2}, {6,4, 2}};
        int[][] indexes = new int[][]{
                {0,1},{0,3},{0,5},
                {1,0},{1,1},{1,2},{1,3},{1,4},{1,5},{1,6},
                {2,1},{2,3},{2,5},
                {3,0},{3,1},{3,2},{3,3},{3,4},{3,5},{3,6},
                {4,1},{4,3},{4,5},
                {5,0},{5,1},{5,2},{5,3},{5,4},{5,5},{5,6},
                {6,1},{6,3},{6,5}};

        // first, put TileCurve with no treasures in the corners
        for (int i = 0; i < 4; i++) {
            TileCurve tile = (TileCurve) _tiles.get(0);
            _tiles.remove(0);
            tile.rotate(1,(i+1));
            _board.setTile(corners[i][0], corners[i][1], tile);
        }

        // then, put TileT in the fixed positions
        for (int i = 0; i < 12; i++) {
            TileT tile = (TileT) _tiles.get(_tiles.size()-1);
            _tiles.remove(_tiles.size()-1);
            tile.rotate(1,tFixed[i][2]);
            _board.setTile(tFixed[i][0], tFixed[i][1], tile);
        }

        // finally, put the rest of the tiles in random positions
        for (int i = 0; i < 33; i++) {
            Tile tile = _tiles.get(0);
            _tiles.remove(0);
            int[] index = indexes[i];
            int rotation = (int) (Math.random() * 4);
            tile.rotate(1,rotation);
            _board.setTile(index[0], index[1], tile);
        }

        return _board;
    }

}
