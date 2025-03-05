package model.tiles;

public class TileT extends Tile {
    public TileT(int id) {
        super(id, "t_tile_p", new boolean[]{false, true, true, true});

    }
    @Override
    public TileType getType() {
        return TileType.T;
    }

}
