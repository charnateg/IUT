package model.tiles;

import helpers.ImageHelper;
import model.Task;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.IOException;

public abstract class Tile {
    private int _id;
    private String _image;
    private boolean[] _directions;
    private Task _task;
    private int _rotation;
    public Tile(int id, String image, boolean[] directions) {
        _id = id;
        _image = image;
        _directions = directions;
        _rotation = 0;
        _task = null;
    }
    public Tile(int id, String image, boolean[] directions, int rotation) {
        _id = id;
        _image = image;
        _directions = directions;
        _rotation = rotation;
        _task = null;
    }

    /**
     * rotate the tile
     * @param direction clockwise = 1, counter-clockwise = -1
     */

    public void rotate(int direction)
    {
        boolean temp;
        if(direction == 1)
        {
             temp= _directions[3];
            for(int i = 3; i > 0; i--)
            {
                _directions[i] = _directions[i-1];
            }
            _directions[0] = temp;
        }
        else
        {
            temp = _directions[0];
            for(int i = 0; i < 3; i++)
            {
                _directions[i] = _directions[i+1];
            }
            _directions[3] = temp;
        }
        _rotation += direction;
        _rotation = (_rotation + 4) % 4;
    }

    public void rotate(int direction, int times)
    {
        for(int i = 0; i < times; i++)
        {
            rotate(direction);
        }
    }

    public void setTask(Task task) {
        _task = task;
    }

    public Task removeTask() {
        Task task = _task;
        _task = null;
        return task;
    }
    public int getId() {
        return _id;
    }

    public Image getImage() throws IOException {
        Image img = ImageIO.read(getClass().getResource("/img/tiles/" + _image + ".png"));
        if(_rotation != 0)
        {
            return ImageHelper.rotate((BufferedImage) img, Math.PI * _rotation / 2);
        }
        return img;
    }

    public String getImagePath() {
        return "/img/tiles/" + _image + ".png";
    }

    public Image getBigImage() throws IOException {
        Image img = ImageIO.read(getClass().getResource("/img/tiles/big_" + _image + ".png"));
        if(_rotation != 0)
        {
            return ImageHelper.rotate((BufferedImage) img, Math.PI * _rotation / 2);
        }
        return img;
    }

    public boolean[] getDirections() {
        return _directions;
    }
    public int getRotation() {
        return _rotation;
    }

    public Task getTask() {
        if (_task == null) return null;
        return _task;
    }
    public abstract TileType getType();
}
