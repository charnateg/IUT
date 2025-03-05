package helpers;
import javax.swing.*;
import java.awt.*;

public class RoundedLabel extends JLabel {
    private int radius; // Corner radius for the rounded rectangle
    private Color backgroundColor; // Background color for the label
    private Color borderColor; // Border color for the label
    private int borderWidth; // Border width for the label

    // Constructor with text
    public RoundedLabel(String text, int radius) {
        super(text);
        this.radius = radius;
        this.backgroundColor = Color.WHITE;
        setOpaque(false); // Make the background transparent to enable custom rendering
    }

    // Setters for customization
    public void setBackgroundColor(Color backgroundColor) {
        this.backgroundColor = backgroundColor;
    }

    public void setBorderColor(Color borderColor) {
        this.borderColor = borderColor;
    }

    public void setBorderWidth(int borderWidth) {
        this.borderWidth = borderWidth;
    }

    @Override
    protected void paintComponent(Graphics g) {
        Graphics2D g2 = (Graphics2D) g;
        g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);

        // Draw the rounded rectangle background
        g2.setColor(backgroundColor);
        g2.fillRoundRect(0, 0, getWidth(), getHeight(), radius, radius);

        // Draw the border
        if (borderWidth > 0) {
            g2.setColor(borderColor);
            g2.setStroke(new BasicStroke(borderWidth));
            g2.drawRoundRect(borderWidth / 2, borderWidth / 2, getWidth() - borderWidth, getHeight() - borderWidth, radius, radius);
        }

        // Paint the text (call the superclass to handle text rendering)
        super.paintComponent(g);
    }

    @Override
    public void setOpaque(boolean isOpaque) {
        super.setOpaque(false); // Always keep the label non-opaque for custom rendering
    }

    @Override
    protected void paintBorder(Graphics g) {
        // Disable default border painting
    }
}
