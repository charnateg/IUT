package model;

public class Position {
    public int row;
    public int col;
    public Position(int row, int col) {
        this.row = row;
        this.col = col;
    }

    @Override
    public boolean equals(Object obj) {
        // Check if the object is the same as the current instance
        if (this == obj) {
            return true;
        }

        // Check if the object is of the correct type
        if (obj == null || getClass() != obj.getClass()) {
            return false;
        }

        // Cast the object to a Position
        Position other = (Position) obj;

        // Compare the row and col values
        return this.row == other.row && this.col == other.col;
    }

}
