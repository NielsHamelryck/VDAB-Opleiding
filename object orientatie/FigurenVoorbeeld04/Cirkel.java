import java.awt.*;
import java.awt.geom.*;

public class Cirkel extends Figuur
{
    private int diameter;
    
    /**
     * Maak een nieuwe Cirkel met een default positie en kleur
     */
    public Cirkel()
    {
        super(230,90,"blue");
        diameter = 68;
    }

    /**
     * Verander de grootte van de cirkel
     */
    public void veranderGrootte(int newDiameter)
    {
        wis();
        diameter = newDiameter;
        teken();
    }

    /**
     * Teken de cirkel met de huidige instellingen op het scherm.
     */
    public void teken()
    {
        if(isZichtbaar()) {
            Canvas canvas = Canvas.getCanvas();
            canvas.draw(this, getKleur(), new Ellipse2D.Double(getXPositie(), getYPositie(), 
                                                          diameter, diameter));
            canvas.wait(10);
        }
    }

}
