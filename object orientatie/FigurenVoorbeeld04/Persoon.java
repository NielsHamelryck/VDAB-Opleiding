import java.awt.*;

public class Persoon extends Figuur
{
    private int hoogte;
    private int breedte;

    /**
     * Maak een nieuw persoon met default specificaties
     */
    public Persoon()
    {
        super(280, 190, "black");
        hoogte = 60;
        breedte = 30;
    }

    /**
     * verander de grootte adhv gegeven hoogte en breedte
     */
    public void veranderGrootte(int hoogte, int breedte)
    {
        wis();
        this.hoogte = hoogte;
        this.breedte = breedte;
        teken();
    }

    /**
     * Draw the person with current specifications on screen.
     */
    public void teken()
    {
        int bh = (int)(hoogte * 0.7);  // body height
        int hh = (hoogte - bh) / 2;  // half head height
        int hw = breedte / 2;  // half width
        int x = getXPositie();
        int y = getYPositie();
        if(isZichtbaar()) {
            Canvas canvas = Canvas.getCanvas();
            int[] xpoints = { x-3, x-hw, x-hw, x-(int)(hw*0.2)-1, x-(int)(hw*0.2)-1, x-hw, 
                              x-hw+(int)(hw*0.4)+1, x, x+hw-(int)(hw*0.4)-1, x+hw, x+(int)(hw*0.2)+1, 
                              x+(int)(hw*0.2)+1, x+hw, x+hw, x+3, x+(int)(hw*0.6), 
                              x+(int)(hw*0.6), x+3, x-3, x-(int)(hw*0.6), x-(int)(hw*0.6) };
            int[] ypoints = { y, y+(int)(bh*0.2), y+(int)(bh*0.4), y+(int)(bh*0.2), 
                              y+(int)(bh*0.5), y+bh, y+bh, y+(int)(bh*0.65), y+bh, y+bh, 
                              y+(int)(bh*0.5), y+(int)(bh*0.2), y+(int)(bh*0.4), y+(int)(bh*0.2), 
                              y, y-hh+3, y-hh-3, y-hh-hh, y-hh-hh, y-hh-3, y-hh+3 };
            canvas.draw(this, getKleur(), new Polygon(xpoints, ypoints, 21));
            canvas.wait(10);
        }
    }

}
