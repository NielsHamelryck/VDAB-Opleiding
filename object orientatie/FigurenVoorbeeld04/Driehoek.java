import java.awt.*;

public class Driehoek extends Figuur
{
    private int hoogte;
    private int breedte;

    /**
     * Maak een driehoek met default positie, hoogte, breedte en kleur
     */
    public Driehoek()
    {
        super(210, 140, "green");
        hoogte = 60;
        breedte = 70;
    }

    /**
     * Verander de grootte adhv het gegeven hoogte en breedte in pixels
     */
    public void veranderGrootte(int hoogte, int breedte)
    {
        wis();
        this.hoogte = hoogte;
        this.breedte = breedte;
        teken();
    }

    /**
     * Teken het driehoek met de huidige specificaties op het scherm
     */
    public void teken()
    {
        if(isZichtbaar()) {
            Canvas canvas = Canvas.getCanvas();
            int xPos = getXPositie();
            int yPos = getYPositie();
            int[] xpoints = { xPos, xPos + (breedte/2), xPos - (breedte/2) };
            int[] ypoints = { yPos, yPos + hoogte, yPos + hoogte };
            canvas.draw(this, getKleur(), new Polygon(xpoints, ypoints, 3));
            canvas.wait(10);
        }
    }

}
