package FigurenVoorbeeld03;

import java.awt.*;

/**
 * A triangle that can be manipulated and that draws itself on a canvas.
 * 
 * @author  Michael Kölling and David J. Barnes
 * @version 2011.07.31
 */

public class Driehoek
{
    private int height;
    private int width;
    private int xPosition;
    private int yPosition;
    private String color;
    private boolean isVisible;

    /**
     * Create a new triangle at default position with default color.
     */
    public Driehoek()
    {
        height = 60;
        width = 70;
        xPosition = 210;
        yPosition = 140;
        color = "green";
        isVisible = false;
    }

    /**
     * Make this triangle visible. If it was already visible, do nothing.
     */
    public void maakZichtbaar()
    {
        isVisible = true;
        teken();
    }
    
    /**
     * Make this triangle invisible. If it was already invisible, do nothing.
     */
    public void maakOnzichtbaar()
    {
        wis();
        isVisible = false;
    }
    
    /**
     * Move the triangle a few pixels to the right.
     */
    public void beweegRechts()
    {
        beweegHorizontaal(20);
    }

    /**
     * Move the triangle a few pixels to the left.
     */
    public void beweegLinks()
    {
        beweegHorizontaal(-20);
    }

    /**
     * Move the triangle a few pixels up.
     */
    public void beweegBoven()
    {
        beweegVertikaal(-20);
    }

    /**
     * Move the triangle a few pixels down.
     */
    public void beweegBeneden()
    {
        beweegVertikaal(20);
    }

    /**
     * Move the triangle horizontally by 'distance' pixels.
     */
    public void beweegHorizontaal(int distance)
    {
        wis();
        xPosition += distance;
        teken();
    }

    /**
     * Move the triangle vertically by 'distance' pixels.
     */
    public void beweegVertikaal(int distance)
    {
        wis();
        yPosition += distance;
        teken();
    }

    /**
     * Slowly move the triangle horizontally by 'distance' pixels.
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
     * Slowly move the triangle vertically by 'distance' pixels.
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
    public void veranderGrootte(int newHeight, int newWidth)
    {
        wis();
        height = newHeight;
        width = newWidth;
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
     * Draw the triangle with current specifications on screen.
     */
    private void teken()
    {
        if(isVisible) {
            Canvas canvas = Canvas.getCanvas();
            int[] xpoints = { xPosition, xPosition + (width/2), xPosition - (width/2) };
            int[] ypoints = { yPosition, yPosition + height, yPosition + height };
            canvas.draw(this, color, new Polygon(xpoints, ypoints, 3));
            canvas.wait(10);
        }
    }

    /**
     * Erase the triangle on screen.
     */
    private void wis()
    {
        if(isVisible) {
            Canvas canvas = Canvas.getCanvas();
            canvas.erase(this);
        }
    }
}
