
/**
 * Abstract class Figuur - write a description of the class here
 * 
 * @author (your name here)
 * @version (version number or date here)
 */
public abstract class Figuur
{
    // instance variables - replace the example below with your own
    private int xPosition;
    private int yPosition;
    private String color;
    private boolean isVisible;
    
    /**
     * Maak een nieuw Figuur
     */
    public Figuur(int xPosition, int yPosition, String color)
    {
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.color = color;
    }

    /**
     * Maak dit figuur zichtbaar
     */
    public void maakZichtbaar()
    {
        isVisible = true;
        teken();
    }

    /**
     * Maak dit figuur onzichtbaar
     */
    public void maakOnzichtbaar()
    {
        wis();
        isVisible = false;
    }
    
    /**
     * Beweeg dit figuur 20 pixels naar rechts
     */
    public void beweegRechts()
    {
        beweegHorizontaal(20);
    }

    /**
     * Beweeg dit figuur 20 pixels naar links
     */
    public void beweegLinks()
    {
        beweegHorizontaal(-20);
    }

    /**
     * Beweeg dit figuur 20 pixels naar boven
     */
    public void beweegBoven()
    {
        beweegVertikaal(-20);
    }

    /**
     * Beweeg dit figuur 20 pixels naar beneden
     */
    public void beweegBeneden()
    {
        beweegVertikaal(20);
    }

    /**
     * Beweeg dit figuur horizontaal adhv het aantal gegeven pixels
     */
    public void beweegHorizontaal(int distance)
    {
        wis();
        xPosition += distance;
        teken();
    }

    /**
     * Beweeg dit figuur vertikaal adhv het aantal gegeven pixels
     */
    public void beweegVertikaal(int distance)
    {
        wis();
        yPosition += distance;
        teken();
    }

    /**
     * Beweeg langzaam dit figuur horizontaal adhv het aantal gegeven pixels
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
     * Beweeg langzaam dit figuur verticaal adhv het aantal gegeven pixels
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
     * Pas de kleur aan, mogelijke kleuren zijn "red", "yellow", "blue", "green", "magenta" and "black".
     */
    public void veranderKleur(String newColor)
    {
        color = newColor;
        teken();
    }

    /**
     * Wis het figuur van het scherm
     */
    public void wis()
    {
        if(isVisible) {
            Canvas canvas = Canvas.getCanvas();
            canvas.erase(this);
        }
    }

    /**
     * Bepaal of het figuur zichtbaar is
     */
    public boolean isZichtbaar()
    {
        return isVisible;
    }
    
    /**
     * Geef de kleur van het figuur
     */
    public String getKleur()
    {
        return color;
    }
    
    /**
     * Geef de positie op de x-as
     */
    public int getXPositie()
    {
        return xPosition;
    }
    
    /**
     * Geef de positie op de y-as
     */
    public int getYPositie()
    {
        return yPosition;
    }
    
    /**
     * Teken dit figuur op het scherm. 
     * Dit is een abstracte method, het moet in de subclasses gedefinieerd worden.
     */
    public abstract void teken();

}
