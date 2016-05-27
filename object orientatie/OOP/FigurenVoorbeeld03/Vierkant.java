package FigurenVoorbeeld03;

import java.awt.*;

/**
 * A square that can be manipulated and that draws itself on a canvas.
 * 
 * @author  Michael Kölling and David J. Barnes
 * @version 2011.07.31
 */

public class Vierkant
{
    private int size;
    private int xPosition;
    private int yPosition;
    private String color;
    private boolean isVisible;

    /**
     * Create a new square at default position with default color.
     */
    public Vierkant()
    {
        size = 60;
        xPosition = 310;
        yPosition = 120;
        color = "red";
        isVisible = false;
    }

    /**
     * Make this square visible. If it was already visible, do nothing.
     */
    public void maakZichtbaar()
    {
        isVisible = true;
        teken();
    }
    
    /**
     * Make this square invisible. If it was already invisible, do nothing.
     */
    public void maakOnzichtbaar()
    {
        wis();
        isVisible = false;
    }
    
    /**
     * Move the square a few pixels to the right.
     */
    public void beweegRechts()
    {
        beweegHorizontaal(20);
    }

    /**
     * Move the square a few pixels to the left.
     */
    public void beweegLinks()
    {
        beweegHorizontaal(-20);
    }

    /**
     * Move the square a few pixels up.
     */
    public void beweegBoven()
    {
        beweegVertikaal(-20);
    }

    /**
     * Move the square a few pixels down.
     */
    public void beweegBeneden()
    {
        beweegVertikaal(20);
    }

    /**
     * Move the square horizontally by 'distance' pixels.
     */
    public void beweegHorizontaal(int distance)
    {
        wis();
        xPosition += distance;
        teken();
    }

    /**
     * Move the square vertically by 'distance' pixels.
     */
    public void beweegVertikaal(int distance)
    {
        wis();
        yPosition += distance;
        teken();
    }

    /**
     * Slowly move the square horizontally by 'distance' pixels.
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
     * Slowly move the square vertically by 'distance' pixels.
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
    public void veranderGrootte(int newSize)
    {
        wis();
        size = newSize;
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
     * Draw the square with current specifications on screen.
     */
    private void teken()
    {
        if(isVisible) {
            Canvas canvas = Canvas.getCanvas();
            canvas.draw(this, color,
                        new Rectangle(xPosition, yPosition, size, size));
            canvas.wait(10);
        }
    }

    /**
     * Erase the square on screen.
     */
    private void wis()
    {
        if(isVisible) {
            Canvas canvas = Canvas.getCanvas();
            canvas.erase(this);
        }
    }
}
