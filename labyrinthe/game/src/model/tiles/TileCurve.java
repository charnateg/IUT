package model.tiles;

public class TileCurve extends Tile {
    public TileCurve(int id) {
        super(id, "c_tile_p", new boolean[]{true, true, false, false});
    }
    @Override
    public TileType getType() {
        return TileType.CURVE;
    }
}
