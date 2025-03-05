package model.factories;

import model.tiles.*;

public class TileFactory {
    public TileFactory() {
    }

    public TileCurve createTileCurve(int id) {
        return new TileCurve(id);
    }
    public TileStraight createTileStraight(int id) {
        return new TileStraight(id);
    }
    public TileT createTileT(int id) {
        return new TileT(id);
    }
}
