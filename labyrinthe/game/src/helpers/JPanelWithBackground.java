package helpers;

import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.io.IOException;

public class JPanelWithBackground extends JPanel {

    private Image backgroundImage;

    // Some code to initialize the background image.
    // Here, we use the constructor to load the image. This
    // can vary depending on the use case of the panel.
    public JPanelWithBackground() throws IOException {
        backgroundImage = ImageIO.read(getClass().getResource("/img/sample_p.png"));
    }

    public void paintComponent(Graphics g) {
        super.paintComponent(g);

        // Draw the background image.
        g.drawImage(backgroundImage, 0, 0, this);
    }
}
