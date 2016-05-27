import java.awt.*;

public class Vierkant extends Figuur
{
    private int grootte;

    /**
     * Maak een nieuwe vierkant met default positie, grootte en kleur
     */
    public Vierkant()
    {
        super(310, 120, "red");
        grootte = 60;
    }


    /**
     * Verander de grootte naar de gegeven grootte
     */
    public void veranderGrootte(int grootte)
    {
        wis();
        this.grootte = grootte;
        teken();
    }

    /**
     * Teken de vierkant met de huidige specificaties op het scherm
     */
    public void teken()
    {
        if(isZichtbaar()) {
            Canvas canvas = Canvas.getCanvas();
            canvas.draw(this, getKleur(),
                        new Rectangle(getXPositie(), getYPositie(), grootte, grootte));
            canvas.wait(10);
        }
    }

}
