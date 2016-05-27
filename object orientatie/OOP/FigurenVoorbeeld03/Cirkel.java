package FigurenVoorbeeld03;

import java.awt.*;
import java.awt.geom.*;

/**
 * A circle that can be manipulated and that draws itself on a canvas.
 * 
 * @author  Michael Kölling and David J. Barnes
 * @version 2011.07.31
 */

public class Cirkel
{
    private int diameter;
    private int xPosition;
    private int yPosition;
    private String color;
    private boolean isVisible;
    
    /**
     * Create a new circle at default position with default color.
     */
    public Cirkel()
    {
        diameter = 68;
        xPosition = 230;
        yPosition = 90;
        color = "blue";
    }

    /**
     * Make this circle visible. If it was already visible, do nothing.
     */
    public void maakZichtbaar()
    {
        isVisible = true;
        teken();
    }
    
    /**
     * Make this circle invisible. If it was already invisible, do nothing.
     */
    public void maakOnzichtbaar()
    {
        wis();
        isVisible = false;
    }
    
    /**
     * Move the circle a few pixels to the right.
     */
    public void beweegRechts()
    {
        beweegHorizontaal(20);
    }

    /**
     * Move the circle a few pixels to the left.
     */
    public void beweegLinks()
    {
        beweegHorizontaal(-20);
    }

    /**
     * Move the circle a few pixels up.
     */
    public void beweegBoven()
    {
        beweegVertikaal(-20);
    }

    /**
     * Move the circle a few pixels down.
     */
    public void beweegBeneden()
    {
        beweegVertikaal(20);
    }

    /**
     * Move the circle horizontally by 'distance' pixels.
     */
    public void beweegHorizontaal(int distance)
    {
        wis();
        xPosition += distance;
        teken();
    }

    /**
     * Move the circle vertically by 'distance' pixels.
     */
    public void beweegVertikaal(int distance)
    {
        wis();
        yPosition += distance;
        teken();
    }

    /**
     * Slowly move the circle horizontally by 'distance' pixels.
     */
    public void traagBeweegHorizontaal(int distance)
    {
        int delta;

        if(distance < 0) 
        {
            delta = -1;
            distance = -distance;
        }
        else 
        {
            delta = 1;
        }

        for(int i = 0; i < distance; i++)
        {
            xPosition += delta;
            teken();
        }
    }

    /**
     * Slowly move the circle vertically by 'distance' pixels.
     */
    public void traagBeweegVertikaal(int distance)
    {
        int delta;

        if(distance < 0) 
        {
            delta = -1;
            distance = -distance;
        }
        else 
        {
            delta = 1;
        }

        for(int i = 0; i < distance; i++)
        {
            yPosition += delta;
            teken();
        }
    }

    /**
     * Change the size to the new size (in pixels). Size must be >= 0.
     */
    public void veranderGrootte(int newDiameter)
    {
        wis();
        diameter = newDiameter;
        teken();
    }

    /**
     * Change the color. Valid colors are "red", "yellow", "blue", "green",
     * "magenta" and "black".
     */
    public void veranderKleur(String newColor)
    {
        color = newColor;
        teken();
    }

    /**
     * Draw the circle with current specifications on screen.
     */
    private void teken()
    {
        if(isVisible) {
            Canvas canvas = Canvas.getCanvas();
            canvas.draw(this, color, new Ellipse2D.Double(xPosition, yPosition, 
                                                          diameter, diameter));
            canvas.wait(10);
        }
    }

    /**
     * Erase the circle on screen.
     */
    private void wis()
    {
        if(isVisible) {
            Canvas canvas = Canvas.getCanvas();
            canvas.erase(this);
        }
    }
}
