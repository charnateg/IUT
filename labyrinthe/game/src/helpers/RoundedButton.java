package helpers;

import javax.swing.*;
import java.awt.*;

public class RoundedButton extends JButton {
    private int radius; // Corner radius for the rounded rectangle

    public RoundedButton(String text, int radius) {
        super(text);
        this.radius = radius;
        setOpaque(false); // Make the button non-opaque for custom rendering
        setFocusPainted(false); // Disable the focus painting
        setContentAreaFilled(false); // Disable default background rendering
        setBorderPainted(false); // Disable default border painting
    }

    @Override
    protected void paintComponent(Graphics g) {
        Graphics2D g2 = (Graphics2D) g;
        g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);

        // Draw the button background
        if (getModel().isPressed()) {
            g2.setColor(new Color(169, 169, 169)); // Slightly darker when pressed
        } else {
            g2.setColor(getBackground());
        }
        g2.fillRoundRect(0, 0, getWidth(), getHeight(), radius, radius);

        // Paint the text
        super.paintComponent(g);
    }

    @Override
    public void setContentAreaFilled(boolean b) {
        // Override to ensure no default painting
    }
}
