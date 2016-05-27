package FigurenVoorbeeld03;

import java.awt.*;

/**
 * A person that can be manipulated and that draws itself on a canvas.
 * 
 * @author  Michael Kölling and David J. Barnes
 * @version 2011.07.31
 */

public class Persoon
{
    private int height;
    private int width;
    private int xPosition;
    private int yPosition;
    private String color;
    private boolean isVisible;

    /**
     * Create a new person at default position with default color.
     */
    public Persoon()
    {
        height = 60;
        width = 30;
        xPosition = 280;
        yPosition = 190;
        color = "black";
        isVisible = false;
    }

    /**
     * Make this person visible. If it was already visible, do nothing.
     */
    public void maakZichtbaar()
    {
        isVisible = true;
        teken();
    }
    
    /**
     * Make this person invisible. If it was already invisible, do nothing.
     */
    public void maakOnzichtbaar()
    {
        wis();
        isVisible = false;
    }
    
    /**
     * Move the person a few pixels to the right.
     */
    public void beweegRechts()
    {
        beweegHorizontaal(20);
    }

    /**
     * Move the person a few pixels to the left.
     */
    public void beweegLinks()
    {
        beweegHorizontaal(-20);
    }

    /**
     * Move the person a few pixels up.
     */
    public void beweegBoven()
    {
        beweegVertikaal(-20);
    }

    /**
     * Move the person a few pixels down.
     */
    public void beweegBeneden()
    {
        beweegVertikaal(20);
    }

    /**
     * Move the person horizontally by 'distance' pixels.
     */
    public void beweegHorizontaal(int distance)
    {
        wis();
        xPosition += distance;
        teken();
    }

    /**
     * Move the person vertically by 'distance' pixels.
     */
    public void beweegVertikaal(int distance)
    {
        wis();
        yPosition += distance;
        teken();
    }

    /**
     * Slowly move the person horizontally by 'distance' pixels.
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
     * Slowly move the person vertically by 'distance' pixels.
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
     * Draw the person with current specifications on screen.
     */
    private void teken()
    {
        int bh = (int)(height * 0.7);  // body height
        int hh = (height - bh) / 2;  // half head height
        int hw = width / 2;  // half width
        int x = xPosition;
        int y = yPosition;
        if(isVisible) {
            Canvas canvas = Canvas.getCanvas();
            int[] xpoints = { x-3, x-hw, x-hw, x-(int)(hw*0.2)-1, x-(int)(hw*0.2)-1, x-hw, 
                              x-hw+(int)(hw*0.4)+1, x, x+hw-(int)(hw*0.4)-1, x+hw, x+(int)(hw*0.2)+1, 
                              x+(int)(hw*0.2)+1, x+hw, x+hw, x+3, x+(int)(hw*0.6), 
                              x+(int)(hw*0.6), x+3, x-3, x-(int)(hw*0.6), x-(int)(hw*0.6) };
            int[] ypoints = { y, y+(int)(bh*0.2), y+(int)(bh*0.4), y+(int)(bh*0.2), 
                              y+(int)(bh*0.5), y+bh, y+bh, y+(int)(bh*0.65), y+bh, y+bh, 
                              y+(int)(bh*0.5), y+(int)(bh*0.2), y+(int)(bh*0.4), y+(int)(bh*0.2), 
                              y, y-hh+3, y-hh-3, y-hh-hh, y-hh-hh, y-hh-3, y-hh+3 };
            canvas.draw(this, color, new Polygon(xpoints, ypoints, 21));
            canvas.wait(10);
        }
    }

    /**
     * Erase the person on screen.
     */
    private void wis()
    {
        if(isVisible) {
            Canvas canvas = Canvas.getCanvas();
            canvas.erase(this);
        }
    }
}
