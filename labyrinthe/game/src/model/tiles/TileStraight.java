package model.tiles;

public class TileStraight extends Tile{
    public TileStraight(int id) {
        super(id, "s_tile_p", new boolean[] {false, true, false, true});
    }
    @Override
    public TileType getType() {
        return TileType.STRAIGHT;
    }
}
